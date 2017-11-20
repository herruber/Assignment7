(function () {

    var app = angular.module("personApp", []);

    var PersonController = function ($scope, $http) {
        //$scope.data = "this will contain data..";

        $scope.initVariables = function()
        {
            $scope.showCreate = false;
            $scope.showPeople = false;
        }

        //$scope.sendData = function () {
        //    //http.post passes on a model
        //    $http.post('/api/Person/PostPerson', $scope.Models.Person)
        //    .then(function (response) {
        //        $scope.data.push(angular.copy($scope.Models.Person));
        //        $scope.ClearForm();

        //    });
        //}

        $scope.sendData = function () {
            //http.post passes on a model
            $http.post('/api/Person/PostPerson', $scope.Models.Person)
            .then(function (response) {
                $scope.data.push(angular.copy($scope.Models.Person));
                $scope.ClearForm();


                $scope.getData();

            });
        }

        $scope.getData = function () {
            $http.get('/api/Person/getPersons')
            .then(function (response) {
                
                $scope.data = response.data;
            });
        }


        $scope.initData = function () {
            $scope.orderDir = true;
            $scope.orderType = "Name";
            $scope.edit = false;

            $scope.getData();
        }


        //Clear form named frm
        $scope.ClearForm = function() {
            document.forms['frm'].reset()
        }

        //Using test = index of the item we want to remove.
        //Avoid using $index, when filtering a list the filtered list indexes do not equal the data list indexes.
        $scope.removeData = function(item)
        {
            //To avoid getting wrong index
            var test = $scope.data.indexOf(item);

                $http.get('/api/Person/DeletePerson/' + item.ID)
                .then(function (response) {

                    //Got index before item was removed from DB
                    $scope.data.splice(test, 1);
                });

                debugger;
        }

        $scope.getSearchData = function (searchTerm, Option) {
            $http.get('/api/Person/GetPerson/' +searchTerm +Option)
            .then(function (response) {
                alert(searchTerm)

                $scope.data = response.data;
                debugger;
            });
        }

        $scope.editData = function(person, name, city, occ)
        {

            alert(occ)
            if (!name && !city && !occ) {

            }
            else { //IF one or more fields have been changed

                if (name) {
                    person.Name = name;
                }

                if (city) {
                    person.City = city;
                }

                if (occ) {
                    person.Occupation = occ;
                }

                person.Name = name;
                person.City = city;
                person.Occupation = occ;

                $http.post('/api/Person/PostPerson', person)

            }


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