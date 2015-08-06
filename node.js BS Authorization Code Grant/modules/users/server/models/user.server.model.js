'use strict';

/**
 * Module dependencies.
 */
var mongoose = require('mongoose'),
    Schema = mongoose.Schema;

var UserSchema = new Schema({
    displayName: {
        type: String,
        trim: true,
        required: true
    },
    roles: {
        type: [{
            type: String,
            enum: ['user', 'admin']
        }],
        default: ['user']
    },
    email: {
        type: String,
        trim: true,
        required: true
    },
    username: {
        type: String,
        unique: true,
        required: true,
        trim: true
    },
    provider: {
        type: String,
        required: true
    },
    token: {
        type: String,
        required: true
    }
});

mongoose.model('User', UserSchema);
