
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
        $('body').on('click', '#lnkProductDescription', function (e) {
            var productID = e.currentTarget.getAttribute("data-id");
            getProductByID(productID);
        });
        $('body').on('click', '#lnkSignUp', function (e) {
            //console.log("Here");
            registerUser(e);
        });
        $('body').on('change', '#inputState', function () {
            //console.log("Here");
            var selectedState = $('select#inputState option:selected').attr('itemid');
            getDistrictByStateID(selectedState);

        });
        
    }
    function getProductByID(productID) {
     
        helper.makeRequest(constant.APP_GET_PRODUCT_BY_ID+"?id="+productID+"", "get", "application/json", null, function (response) {
           
            $("#content-wrapper").html(response);
        });
    }
    function getDistrictByStateID(stateID) {
        
        helper.makeRequest("/Account/GetDistrictByStateID?id="+stateID+"", "get", "application/json",  null, function (response) {
            //window.location.reload();
            $("#content-wrapper").html(response);
        });
    }
    function authenticateUser() {
        var email = $("#exampleFormControlInput1").val();
        var password = $("#exampleFormControlInput2").val();
        const authenticateUser = { email: email, password: password };
        const data = JSON.stringify(authenticateUser);
        helper.makeRequest(constant.APP_AUTHENTICATE_USER, "post", "application/json", data, function (response) {
           
            $("#content-wrapper").html(response);
             //window.location.reload(true);
        });
    } 
    function registerUser(e) {
        var email = $("#inputEmail4").val();
        var password = $("#inputPassword4").val();
        var address = $("#inputAddress").val();
       // var address2 = $("#inputAddress2").val();
        var state = $("#inputState").val();
        var name = $("#inputName").val();
        var age = $("#inputAge").val();
        var stateID = $('select#inputState option:selected').attr('itemid');
        
        //var password = $("#exampleFormControlInput2").val();
        const registerUser = { email: email, password: password,address:address,stateID:stateID,name:name,age:age };
        const data = JSON.stringify(registerUser);
        helper.makeRequest("/Account/RegisterUser", "post", "application/json", data, function (response) {
            //window.location.reload();
            $("#content-wrapper").html(response);
        });
    }
})();