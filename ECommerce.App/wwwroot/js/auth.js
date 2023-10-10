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
        $('body').on('click', '#linkSignIn', function () {
            console.log("Here");
            authentication.authenticateUser();
        });
        $('body').on('click', '#lnkSignUp', function () {
            //console.log("Here");
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
        var postCode = $("#PostCode").val(); // Get the PostCode value

        var userData = {
            Name: name,
            Address: address,
            Email: email,
            Password: password,
            ContactNumber: contactNumber,
            Age: age,
            PostCode: postCode, // Include the PostCode property
            StateID: null, // Most of this value are input from Dropdrown  so we set null initially
            DistrictID: null,
            CityID: null
        };

        // Convert the user data to JSON
        var jsonData = JSON.stringify(userData);

        // Make an AJAX request to the server to register the user
        // Assuming you have a helper function for making AJAX requests
        helper.makeRequest("/Account/Register", "post", "application/json", jsonData, function (response) {
            // Handle the response or perform any necessary actions after registration

            //window.location.reload();
            $("#content-wrapper").html(response);
        });
    }


  
    }
})();