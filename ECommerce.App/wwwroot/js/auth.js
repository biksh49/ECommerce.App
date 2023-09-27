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
        const authenticateUser = { username: email, password: password };
        const data = JSON.stringify(authenticateUser);
        helper.makeRequest("/Home/Authenticate", "post", "application/json", data, function () {

        });
    }
})();