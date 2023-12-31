﻿var helper = (function () {
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
        }).done(function (res,status,xhr) {
            callback(res);
        }).fail(function (response) {
            switch (response.status) {
                case 401:
                    alert("Unauthorized!!");
                    break;
                case 404:
                    alert("Page Not Found!!");
                    break;
                case 400:
                    alert("The password or username is incorrect!!");
                    break;
                default:
                    alert('An error occurred');
                    break;
            }

        })
    }


})();