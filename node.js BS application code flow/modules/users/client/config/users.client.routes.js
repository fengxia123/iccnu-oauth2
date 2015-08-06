'use strict';

// Setting up route
angular.module('users').config(['$stateProvider',
	function ($stateProvider) {
		// Users state routing
		$stateProvider.
			state('authentication', {
				abstract: true,
				url: '/authentication',
				templateUrl: 'modules/users/views/authentication/authentication.client.view.html'
			}).
			state('authentication.welcome', {
				url: '/welcome',
				templateUrl: 'modules/users/views/authentication/welcome.client.view.html'
			});
	}
]);
