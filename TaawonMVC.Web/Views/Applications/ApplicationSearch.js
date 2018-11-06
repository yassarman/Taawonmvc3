// search bar not processed applications  ==================
$(document).ready(function () {
    $("body").on("keyup", "#ApplicationInput", function (event) {

       //  alert("called");
        searchFunction();
    });
});

function searchFunction() {
    var searchinput = document.getElementById("ApplicationInput");
    //alert(searchinput);
    var searchTXT = searchinput.value.toUpperCase();
    var url = abp.appPath + 'Applications/SearchIndex?searchTXT=' + searchTXT;
    var token = $('input[name="__RequestVerificationToken"]').val();
    var headers = {};
    headers['__RequestVerificationToken'] = token;
    //  alert("called2"+ searchTXT);
    $.ajax({
        url: url,
        headers: headers,
        type: 'POST',
        contentType: 'application/html',
        success: function(content) {
            // location.reload(false); //reload page to see new user!  
            $('#ApplicationTableContent').html(content);
            //  alert("called3" + searchTXT);
            //$('#TableContent').load(content);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            // alert("called4" + searchTXT);
            alert(xhr.status);
            alert(thrownError);
        }
    });

}

// end of search bar =================================================
//====================================================================
// search bar projects
$(document).ready(function () {
    $("body").on("keyup", "#ProjectInput", function (event) {

        // alert("called");
        searchProjectFunction();
    });
});

function searchProjectFunction() {
    var searchinput = document.getElementById("ProjectInput");
    //alert(searchinput);
    var searchTXT = searchinput.value.toUpperCase();
    var url = abp.appPath + 'Applications/SearchProjectIndex?searchTXT=' + searchTXT;
    var token = $('input[name="__RequestVerificationToken"]').val();
    var headers = {};
    headers['__RequestVerificationToken'] = token;
    //  alert("called2"+ searchTXT);
    $.ajax({
        url: url,
        headers: headers,
        type: 'POST',
        contentType: 'application/html',
        success: function (content) {
            // location.reload(false); //reload page to see new user!  
            $('#ProjectTableContent').html(content);
            //  alert("called3" + searchTXT);
            //$('#TableContent').load(content);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            // alert("called4" + searchTXT);
            alert(xhr.status);
            alert(thrownError);
        }
    });

}
// end of search bar Projects