(function () {
    'use strict';

    angular
        .module('app')
        .controller('welcome', welcome);
    
    welcome.$inject = ['photoManager'];

    function welcome(photoManager) {
        var vm = this;
        vm.photosGallery = photoManager.photosGallery;
        
        activate();

        function activate() {
            photoManager.load();
        }
    }
})();
