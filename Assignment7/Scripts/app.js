(function () {

    var app = angular.module("personApp", []);

    var PersonController = function ($scope, $http) {
        $scope.data = "this will contain data..";

        $scope.sendData = function () {
            //http.post passes on a model
            $http.post('/api/Person/PostPerson', $scope.Models.Person)
            .then(function (response) {
                $scope.data.push(angular.copy($scope.Models.Person));
                $scope.ClearForm() //Clears current form

                //Fixes issue with trying to remove a person not yet published to database
                $scope.getData()
            });
        }

        $scope.getData = function () {
            $http.get('/api/Person/getPersons')
            .then(function (response) {
                //debugger;
                $scope.data = response.data;

            });
        }


        $scope.initData = function () {
            $scope.orderDir = true;
            $scope.orderType = "Name";
            $scope.getData();
        }


        //Clear form named frm
        $scope.ClearForm = function() {
            document.forms['frm'].reset()
        }

        $scope.removeData = function(id, index)
        {

                $http.get('/api/Person/DeletePerson/' + id)
                .then(function (response) {
                $scope.data.splice(index, 1)
            });
               
        }

        $scope.getSearchData = function (searchTerm, Option) {
            $http.get('/api/Person/GetPerson/' +searchTerm +Option)
            .then(function (response) {
                alert(searchTerm)

                $scope.data = response.data;
                debugger;
            });
        }

        $scope.orderSetup = function(input)
        {

            if (input == $scope.orderType) {
                $scope.orderDir = !$scope.orderDir;
            }
            else {
                $scope.orderDir = true;
            }

            $scope.orderType = input;
        }

    };

    app.controller("PersonController", ['$scope', '$http', PersonController]);

}());