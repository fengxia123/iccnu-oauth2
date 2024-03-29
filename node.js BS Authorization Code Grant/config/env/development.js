'use strict';


module.exports = {
    db: 'mongodb://ubuntu:8888/wecourse-dev',
    port:  8080 || process.env.PORT,
    app: {
        title: 'MEAN.JS - Development Environment'
    },
    mailer: {
        from: process.env.MAILER_FROM || 'MAILER_FROM',
        options: {
            service: process.env.MAILER_SERVICE_PROVIDER || 'MAILER_SERVICE_PROVIDER',
            auth: {
                user: process.env.MAILER_EMAIL_ID || 'MAILER_EMAIL_ID',
                pass: process.env.MAILER_PASSWORD || 'MAILER_PASSWORD'
            }
        }
    }
};
