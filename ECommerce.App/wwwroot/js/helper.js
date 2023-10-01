var helper = (function () {
    return {
        makeRequest: function (url, type, contentType, data, callback) {
            makeRequest(url, type, contentType, data, callback);
        }
    };
    function makeRequest(url, type, contentType, data, callback) {
        $.ajax({
            url: url,
            type: type,
            contentType: contentType,
            data: data,
            context: document.body
        }).done(function () {
            callback("success");
        })
        .error(function () {

        });
    }


})();