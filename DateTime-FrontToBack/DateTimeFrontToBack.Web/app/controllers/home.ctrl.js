(function () {
    'use strict';

    angular
        .module('mainApp')
        .controller('homeCtrl', homeCtrl);

    homeCtrl.$inject = ['$log', 'dataSvc'];

    function homeCtrl($log, dataSvc) {
        /* jshint validthis:true */
        var vm = this;
        vm.resetForm = resetForm;
        vm.sharedDate = new Date();
        vm.saveData = saveData;

        function resetForm() {
            vm.sharedDate = new Date();
        }

        function saveData() {
            dataSvc.saveData({ storedDateTime: vm.sharedDate.toISOString() })
                .then(function(data) {
                        $log.log(JSON.stringify(data));
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
