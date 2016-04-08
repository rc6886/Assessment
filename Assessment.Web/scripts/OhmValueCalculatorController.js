angular.module("ohmValueCalculator", [])
.controller("ohmValueCalculatorController", ["$scope", "$http", function (scope, http) {
        scope.resistorBandADropDown = [];
        scope.resistorBandBDropDown = [];
        scope.resistorBandCDropDown = [];
        scope.resistorBandDDropDown = [];

        scope.bandASelectedItem = "";
        scope.bandBSelectedItem = "";
        scope.bandCSelectedItem = "";
        scope.bandDSelectedItem = "";

        scope.ohmValue = "";
        scope.tolerance = "";

        angular.element(document).ready(function() {
            http.get("/OhmValueCalculator/GetDropdownValues")
                .success(function (result) {
                    scope.resistorBandADropDown = result.BandAValues;
                    scope.resistorBandBDropDown = result.BandBValues;
                    scope.resistorBandCDropDown = result.BandCValues;
                    scope.resistorBandDDropDown = result.BandDValues;
                });
        });

        scope.calculate = function() {
            var payload = {
                colorBandA: scope.bandASelectedItem,
                colorBandB: scope.bandBSelectedItem,
                colorBandC: scope.bandCSelectedItem,
                colorBandD: scope.bandDSelectedItem
            };

            http.post("/OhmValueCalculator/Calculate", payload)
                .success(function(result) {
                    scope.ohmValue = result.OhmValue;
                    scope.tolerance = result.Tolerance;
                });
        };

        scope.isDropdownDisabled = function() {
            return scope.bandASelectedItem === "" || scope.bandBSelectedItem === "" || scope.bandCSelectedItem === "" || scope.bandDSelectedItem === "";
        };

        scope.isResultVisible = function() {
            return scope.ohmValue !== "" && scope.tolerance !== "";
        };
    }]);