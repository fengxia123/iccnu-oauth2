'use strict';

/**
 * Auth API
 *
 * @module Users
 * @main auth routes
 * @class auth.server.routes
 */
var passport = require('passport');
var OAuth2Strategy = require('passport-oauth2').Strategy;
var path = require('path');
var config = require(path.resolve('./config/config'));
var mongoose = require('mongoose');
var User = mongoose.model('User');
var query = mongoose.query;

var protocol = config.port === 443 ? require('https') : require('http');

// Serialize sessions
passport.serializeUser(function(user, done) {
    done(null, user.id);
});

// Deserialize sessions
passport.deserializeUser(function(id, done) {
    User.findOne({
        _id: id
    }, function(err, user) {
        done(err, user);
    });
});

passport.use(new OAuth2Strategy({
        authorizationURL: 'http://www.iccnu.net/oauth2/authorize',
        tokenURL: 'http://www.iccnu.net/api/oauth2/token',
        clientID: 'code_test',
        clientSecret: 'code_test',
        callbackURL: 'http://localhost:8080/account/login',
        state: true
    },
    function (accessToken, refreshToken, profile, done) {

        var options = {
            host: 'www.iccnu.net',
            port: 80,
            path: '/api/oauth2/me',
            headers: {
                'Authorization': 'Bearer ' + accessToken
            },
            method: 'GET'
        };

        var req = protocol.request(options, function (res) {

            var body = '';
            res.on('data', function (d) {
                body += d;
            });
            res.on('end', function () {

                // Data reception is done, do whatever with it!
                var parsed = JSON.parse(body);

                var user = {
                    displayName: parsed.displayName,
                    email: parsed.email,
                    username: parsed.username,
                    provider: 'iccnu',
                    token: accessToken
                };

                User.findOneAndUpdate({username: user.username}, user, {upsert: true, new: true}, function (err, newuser) {
                    if (err) {
                        done(err);
                    }
                    done(null, newuser);
                    //go to serializer
                });
            });
        });

        req.on('error', function (e) {
            done(e.message);
        });

        req.end();
    }
))
;

module.exports = function (app) {
    app.route('/api/auth/signout').get(function (req, res) {
        req.logout();
        res.redirect('/');
    });

    app.route('/account').get(passport.authenticate('oauth2'));
    app.route('/account/login').get(passport.authenticate('oauth2',
        {
            failureRedirect: '/server-error',
            successRedirect: '/authentication/welcome'
        }));

    app.route('/api/me').get(function (req, res) {
        return res.send(req.user);
    });
};
