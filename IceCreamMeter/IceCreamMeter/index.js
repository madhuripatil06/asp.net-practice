/// <reference path="C:\Users\madhuri\projects\IceCreamMeter\IceCreamMeter\Scripts/angular.js" />


var MyApp = angular.module("MyApp", ['ngRoute', 'TeamService']);

MyApp.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/Add', {
                templateUrl: 'Views/add.html',
                controller: 'AddController'
            }).
             when('/Edit', {
                 templateUrl: 'Views/edit.html',
                 controller: 'EditController'
             }).
             when('/Delete', {
                 templateUrl: 'Views/delete.html',
                 controller: 'DeleteController'
             }).
             when('/Home', {
                 templateUrl: 'Views/home.html',
                 controller: 'HomeController'
             }).
             otherwise({
                 redirectTo: "/Home"
             });
    }]);

MyApp.controller("AddController", function ($scope, TeamApi) {
    
    $scope.addmember = function () {
        var member = {
            'username': $scope.username,
            'count': $scope.count
        };
        TeamApi.addMember(member).success(function () {
            alert("added");
            $scope.username = undefined;
            $scope.count = undefined;
        })
        .error(function (err) {
            alert("Error!!"+ err.message);
        });
    };
});

MyApp.controller("EditController", function ($scope, TeamApi) {
    $scope.editMember = function () {
        var member = {
            'username': $scope.username,
            'count': $scope.count
        };
        TeamApi.editMember(member).success(function () {
            alert("edited");
            $scope.username = undefined;
            $scope.count = undefined;
        })
        .error(function (err) {
            alert("Error!!" + err.message);
        });
    };
});

MyApp.controller("DeleteController", function ($scope, TeamApi) {
    $scope.deleteMember = function () {
        TeamApi.deleteMember($scope.username).success(function () {
            alert("deleted");
            $scope.username = undefined;
            $scope.count = undefined;
        })
        .error(function (err) {
            alert("Error!!" + err.message);
        });
    };
});

MyApp.controller("HomeController", function ($scope, TeamApi) {
    getTeamMembers();
    function getTeamMembers() {
        TeamApi.getTeamMembers().success(function (members) {
            $scope.members = members;
        })
        .error(function (error) {
            $scope.status = 'Unable to Load ' + error.message;
        })
    }
});