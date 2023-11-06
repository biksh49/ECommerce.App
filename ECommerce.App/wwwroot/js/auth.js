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
        $('body').on('click', '#lnkSignUp', function (e) {
            console.log("Here");
            registerUser(e);
        });
    }

    $('body').on('change', '#inputState', function () {
        //console.log("Here");
        var selectedState = $('select#inputState option:selected').attr('itemid');
        getDistrictByStateID(selectedState);

    });
    $('body').on('change', '#inputDistrict', function () {
        //console.log("Here");
        var selectedDistrict = $('select#inputState option:selected').attr('itemid');
        getCityByDistrictID(selectedDistrict);

    });

    function getDistrictByStateID(StateID) {

        helper.makeRequest("/Account/GetDistrictByStateID?id=" + StateID + "", "get", "application/json", null, function (response) {
            //window.location.reload();
            $("#content-wrapper").html(response);
        });
    }

    function getCityByDistrictID(DistrictID) {

        helper.makeRequest("/Account/GetCityByDistrictID?id=" + DistrictID + "", "get", "application/json", null, function (response) {
            //window.location.reload();
            $("#content-wrapper").html(response);
        });
    }
    function authenticateUser() {
        var email = $("#Email").val();
        var password = $("#Password").val();
        const authenticateUser = { email: email, password: password };
        const data = JSON.stringify(authenticateUser);
        helper.makeRequest("/Account/Authenticate", "post", "application/json", data, function (response) {
            //window.location.reload();
            $("#content-wrapper").html(response);
        });
    }

    function registerUser() {
        var name = $("#inputName").val();
        var age = $("#inputAge").val();
        var email = $("#inputEmail4").val();
        var contactNumber = $("#inputContactNumber").val();
        var password = $("#inputPassword4").val();
        var postCode = $("#inputPostCode").val();
        var stateID = $('select#inputState option:selected').attr('itemid');
        var districtID = $('select#inputDistrict option:selected').attr('itemid');
        var cityID = $('select#inputCity option:selected').attr('itemid');

        var registerUser = {
            Name: name,
            Age: age,
            Email: email,
            ContactNumber: contactNumber,
            PostCode: postCode,
            Password: password,
            StateID: stateID,
            DistrictID: districtID,
            CityID: cityID
        };

        const data = JSON.stringify(registerUser);

        helper.makeRequest("/Account/RegisterUser", "post", "application/json", data, function (response) {
            //if (response.success) {
            //    // Registration was successful, handle as needed
            //    alert("Registration successful!");
            //    // You can redirect or update the UI as appropriate
            //} else {
            //    // Handle registration failure, show an error message, etc.
            //    alert("Registration failed: " + response.errorMessage);
            //}
        });
    }

})();