var authentication = (function () {
    return {
        initialize: function () {
            attachHandler();
        }
    };

    function attachHandler() {
        $('body').on('click', '#linkSignIn', function () {
            console.log("Here");
            authenticateUser();
        });
        $('body').on('click', '#lnkSignUp', function () {
            console.log("Here");
            registerUser();
        });
    }

    function authenticateUser() {
        var email = $("#Email").val();
        var password = $("#Password").val();
        const authenticateUser = { username: email, password: password };
        const data = JSON.stringify(authenticateUser);
        helper.makeRequest("/Account/Authenticate", "post", "application/json", data, function (response) {
            //window.location.reload();
            $("#content-wrapper").html(response);
        });
    }

    function registerUser() {
        var name = $("#Name").val();
        var address = $("#Address").val();
        var email = $("#Email").val();
        var password = $("#Password").val();
        var contactNumber = $("#ContactNumber").val();
        var age = $("#Age").val();
        var postCode = $("#PostCode").val();

        var registerUser = {
            Name: name,
            Address: address,
            Email: email,
            Password: password,
            ContactNumber: contactNumber,
            Age: age,
            PostCode: postCode,
            StateID: null,
            DistrictID: null,
            CityID: null
        };

        const data = JSON.stringify(registerUser);

        helper.makeRequest("/Account/RegisterUser", "post", "application/json", data, function (response) {
            $("#content-wrapper").html(response);
        });
    }
})();