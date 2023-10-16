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
        var name = $("#Name").val();
        var age = $("#Age").val();
        var email = $("#Email").val();
       
        var contactNumber = $("#ContactNumber").val();
        var password = $("#Password").val();
     
        var postCode = $("#PostCode").val();
        var stateID = $("#inputState").val();
        var districtID = $("#inputDistrict").val();
        var cityID = $("#inputCity").val();

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
            $("#content-wrapper").html(response);
        });
    }
})();