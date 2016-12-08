/// <reference path="C:\Users\madhuri\projects\IceCreamMeter\IceCreamMeter\Scripts/angular.js" />

var TeamService = angular.module('TeamService', []);

TeamService.factory('TeamApi', function ($http) {
    var urlBase = "http://localhost:65385/api";
    var TeamApi = {};

    TeamApi.getTeamMembers = function () {
        return $http.get(urlBase + "/team");

    };

    TeamApi.addMember = function (member) {
        var req = $http({
            method: 'post',
            url: urlBase + "/team/" + member.username + "/"+member.count,
        });
        return req;
    };

    TeamApi.editMember = function (member) {
        var req = $http({
            method: 'put',
            url: urlBase + "/team/"+ member.username+"/"+member.count
        });
        return req;
    };

    TeamApi.deleteMember = function (name) {
        var req = $http({
            method: 'delete',
            url: urlBase + "/team/" + name
        });
        return req;
    };


    return TeamApi;
});