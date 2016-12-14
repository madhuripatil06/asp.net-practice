describe("addController", function () {
    beforeEach(angular.mock.module("addController"));
    var $controller;

    beforeEach(angular.mock.inject(function (_$controller_) {
        $controller = _$controller_;
    }));

    describe("add", function () {
        it("add should call teamapi's addmember method", function () {
            var $scope = {};
            var teamApi = {addMember: function(){}};
            var controller = $controller('AddController', { $scope: $scope, TeamApi: teamApi });
            verify(teamApi.addMember.call(1));
        })
    })

});