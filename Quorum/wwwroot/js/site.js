window.croppie = () => {
    //initialize Croppie
    var basic = $('#main-cropper').croppie
        ({
            viewport: { width: 300, height: 300 },
            boundary: { width: 500, height: 400 },
            showZoomer: true,
            url: 'Photos/preview.png',
            format: 'png' | 'jpeg'
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
};

window.getCroppie = () => {
    var result;
    async function getResult (){
        return await $('#main-cropper').croppie('result', 'canvas');
    }
    result = getResult();
    return result.data;
};