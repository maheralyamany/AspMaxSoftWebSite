$(function () {
    $("#save").click(function () {
        var bo = false;
        document.getElementById("span-err").innerHTML = "";
        //check if input is empty
        if (document.getElementById("jobimg").value == "") {
            $("#span-err").append("* ");
            $("#span-err").append("الرجاء اختيار صورة للوظيفة .");
            bo = true;
        }
        if ($("#jobimg").val() != "") {
            //Check if the Image extention is valid
            var filename = document.getElementById("jobimg").value;
            var extentionImg = filename.substr(filename.lastIndexOf('.') + 1);
            var validextention = ['gif', 'bmp', 'png', 'jpg'];
            if ($.inArray(extentionImg, validextention) == -1) {
                if (bo == true) { $("#span-err").append("<br/>"); }
                $("#span-err").append("* ");
                $("#span-err").append("الرجاء اختيار صورة من نوع(jpg , png , gif , bmp)");
                bo = true;
            }
            //Check if the Image Size is valid (2mb)
            var fileSize = document.getElementById("jobimg").files[0].size / 1024 / 1024;
            if (fileSize > 2) {
                if (bo == true) { $("#span-err").append("<br/>"); }
                $("#span-err").append("* ");
                $("#span-err").append("الرجاء اختيار صورة حجمها اقل من 2 ميغا بايت");
                bo = true;
            }
            if (bo == true) {
                $("#div-err").fadeIn();
                return false;
            }
        }
    });
});