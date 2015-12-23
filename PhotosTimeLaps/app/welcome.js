(function () {
    'use strict';

    angular
        .module('app')
        .controller('welcome', welcome);
    
    welcome.$inject = ['photoManager'];

    function welcome(photoManager) {
        var vm = this;
        vm.photos = photoManager.photos;
        vm.previewPhoto;

        activate();

        function activate() {
            photoManager.load();
        }
    }
})();
