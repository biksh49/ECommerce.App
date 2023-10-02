
var authentication = (function () {
    //constant.initialize();
    return {
        initialize: function () {
            attachHandler();
        },
        authenticateUser: function () {
            authenticateUser();
        }
    };
    function attachHandler() {
        $('body').on('click', '#lnkSubmit', function () {
            console.log("Here");
            authentication.authenticateUser();
        });
        
    }
    function authenticateUser() {
        var email = $("#exampleFormControlInput1").val();
        var password = $("#exampleFormControlInput2").val();
        const authenticateUser = { email: email, password: password };
        const data = JSON.stringify(authenticateUser);
        helper.makeRequest("/Account/AuthenticateUser", "post", "application/json", data, function (response) {
            window.location.reload();
            // $("#content-wrapper").html(response);
        });
    } 
})();