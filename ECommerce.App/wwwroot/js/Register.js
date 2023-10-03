var registerUser = (function () {
    return {
        initialize: function () {
            attachHandler();
        },
        registerUser: function () {
            registerUser();
        }
    };

    function attachHandler() {
        $('body').on('click', '#lnkSubmit', function (event) {
            event.preventDefault();
            registerUser.registerUser();
        });
    }

    function registerUser() {
        var name = $("#Name").val();
        var address = $("#Address").val();
        var email = $("#Email").val();
        var password = $("#Password").val();
        var contactNumber = $("#ContactNumber").val();
        var age = $("#Age").val();
        var dob = $("#DOB").val();

        var userData = {
            Name: name,
            Address: address,
            Email: email,
            Password: password,
            ContactNumber: contactNumber,
            Age: age,
            DOB: dob
        };

        // Convert the user data to JSON
        var jsonData = JSON.stringify(userData);

        // Make an AJAX request to the server to register the user
     
        helper.makeRequest("/Account/Register", "post", "application/json; charset=utf-8", data, function () {

        });
    }
})();

// Initialize the registerUser module
//registerUser.initialize();
