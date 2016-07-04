(function () {
    'use strict';

    angular
        .module('mainApp')
        .factory('dataSvc', dataSvc);

    dataSvc.$inject = ['$resource', '$q', 'settings'];

    function dataSvc($resource, $q, settings) {
        var service = {
            saveData: _saveData
        };

        var saveEndpoint = $resource(settings.apiBaseUrl + '/api/poc/post');

        return service;

        function _saveData(data) {
            var deferred = $q.defer();
            saveEndpoint.save(data, function(data) {
                deferred.resolve(data);
            },
            function(error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }
    }
})();