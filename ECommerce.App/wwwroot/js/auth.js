
var authentication = (function () {
    return {
        //initialize: function () {
        //    attachHandler();
           
        //},
        authenticateUser: function () {
            validateuser();
        }
    };
    function attachHandler() {
       
    }
    function validateuser() {
        var email = $("#exampleFormControlInput1").val();
        var password = $("#exampleFormControlInput2").val();
        const authenticateuser = { username: email, password: password };
        const data = JSON.stringify(authenticateuser);
        $.ajax({
            url: "/home/Authenticate?email=" + email + "&password=" + password + "",
            type: "post",
            context: document.body
        }).done(function () {
            $(this).addClass("done");
        });


    } 
})();