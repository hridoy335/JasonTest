$(document).ready(function () {
    alert("Teacher js load");
});

function SaveTeacher() {
   // alert("Yes");
    var name = $("#Name").val();
    var email = $("#Email").val();
    var phone = $("#Phone").val();

    if (name == null || name == "" || typeof (name) == undefined)
    {
        alert("Insert Name ..");
        return;
    }

    if (email == null || email == "" || typeof (email) == undefined) {
        alert("Insert Email ..");
        return;
    }

    if (phone == null || phone == "" || typeof (phone) == undefined) {
        alert("Insert Phone ..");
        return;
    }
    $.ajax({
        type: "POST",
        url: "../Teacher/CreateTeacher",
        data: {
            TeacherName: name,
            TeacherEmail: email,
            TeacherPhone: phone
        },
        success: function (data) {
            alert("Insert Teacher Data ...");
            $("#Name").val("");
            $("#Email").val("");
            $("#Phone").val("");
        }


    });

}