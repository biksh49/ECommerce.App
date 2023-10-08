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
        $('body').on('click', '#SignIn', function () {
            console.log("Here");
            authentication.authenticateUser();
        });

    }
    function authenticateUser() {
        var email = $("#Email").val();
        var password = $("#Password").val();
        const authenticateUser = { username: email, password: password };
        const data = JSON.stringify(authenticateUser);
        helper.makeRequest("/Account/Authenticate", "post", "application/json", data, function () {

        });
    }
})();