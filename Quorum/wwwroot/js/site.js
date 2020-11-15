// Wait until a 'reload' button appears
new MutationObserver((mutations, observer) => {
    if (document.querySelector('#components-reconnect-modal h5 a')) {
    // Now every 10 seconds, see if the server appears to be back, and if so, reload
    async function attemptReload() {
        await fetch(''); // Check the server really is back
        location.reload();
    }
        observer.disconnect();
        attemptReload();
        setInterval(attemptReload, 10000);
    }
}).observe(document.body, {childList: true, subtree: true });

//Croppie js functions
window.croppieFunctions = {
    init: function () {
        $('#main-cropper').croppie
            ({
                viewport: { width: 256, height: 256 },
                boundary: { width: 500, height: 400 },
                showZoomer: true,
                url: 'preview.png',
                format: 'png' //'jpeg'|'png'|'webp'
            });

        //Reading the contents of the specified Blob or File
        function readFile(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#main-cropper').croppie('bind', {
                        url: e.target.result
                    });
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
        // Change Event to Read file content from File input
        $('#select').on('change', function () { readFile(this); });
    }
};
