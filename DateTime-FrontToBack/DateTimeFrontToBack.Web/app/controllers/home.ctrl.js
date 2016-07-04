(function() {
    'use strict';

    angular
        .module('mainApp')
        .controller('homeCtrl', homeCtrl);

    homeCtrl.$inject = ['$log', 'dataSvc'];

    function homeCtrl($log, dataSvc) {
        /* jshint validthis:true */
        var vm = this;
        vm.resetFormStrap = resetFormStrap;
        vm.sharedDateStrap = new Date();
        vm.saveDataStrap = saveDataStrap;

        function resetFormStrap() {
            vm.sharedDateStrap = new Date();
        }

        function saveDataStrap() {
            dataSvc.saveData({ storedDateTime: vm.sharedDateStrap.toISOString() })
                .then(function(data) {
                        $log.log(JSON.stringify(data));
                        vm.returnDataStrap = data;
                    },
                    function rejected(reason) {
                        $log.error(reason);
                    },
                    function notify(update) {
                        $log.info(update);
                    });
        }


        vm.resetFormUiStrap = resetFormUiStrap;
        vm.sharedDateUiStrap = new Date();
        vm.saveDataUiStrap = saveDataUiStrap;
        vm.uiStrapOpened = {
            date: false,
            time: false
        };
        // Disable weekend selection
        function disabled(data) {
            var date = data.date,
              mode = data.mode;
            return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
        }
        vm.dateOptions = {
            dateDisabled: disabled,
            formatYear: 'yy',
            maxDate: new Date(2020, 5, 22),
            minDate: new Date(),
            startingDay: 1
        };

        vm.dateOpen = function() {
            vm.uiStrapOpened.date = true;
        }

        function resetFormUiStrap() {
            vm.sharedDateUiStrap = new Date();
        }

        function saveDataUiStrap() {
            dataSvc.saveData({ storedDateTime: vm.sharedDateUiStrap.toISOString() })
                .then(function (data) {
                    $log.log(JSON.stringify(data));
                    vm.returnDataUiStrap = data;
                },
                    function rejected(reason) {
                        $log.error(reason);
                    },
                    function notify(update) {
                        $log.info(update);
                    });
        }


        
    }
})();
