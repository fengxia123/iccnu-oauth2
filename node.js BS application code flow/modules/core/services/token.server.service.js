'use strict';
// Load required packages
var jwt = require('jwt-simple');
var accessTokenSecret = 'iccnu';

var passport = require('passport');
exports.isClientAuthenticated = passport.authenticate('client-basic', {session: false});
exports.isBearerAuthenticated = passport.authenticate('client-bearer', {session: false});

exports.decode = function (token) {
    return jwt.decode(token, accessTokenSecret, 'HS256');
};

exports.sendLocalToken = function (user, res) {
    var payload = {
        iss: 'www:iccnu.net',
        sub: user.id,
        clientId: 'local'
    };

    var token = jwt.encode(payload, accessTokenSecret, 'HS256');

    res.json({
        user: user.toUserWithoutPasswordHash(),
        token: token
    });
};

exports.createAccessToken = function (sub, clientId) {
    var payload = {
        iss: 'www:iccnu.net',
        sub: sub,
        clientId: clientId
    };
    return jwt.encode(payload, accessTokenSecret, 'HS256');
};
