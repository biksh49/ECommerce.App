
    //console.log(authentication.authenticateUser());
    $(document).ready(function () {
        
        //authentication.initialize();
        $('body').on('click', '#linkSubmit', function () {
            console.log("Here");
            authentication.authenticateUser();
        });
    });




