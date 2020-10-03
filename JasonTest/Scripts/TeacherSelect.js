$(document).ready(function () {
    alert("Teacher select js  Load.. ");
    getTeacher();
})

function getTeacher() {
    $.ajax({
        type: "GET",
        url: "../Teacher/ViewTeacher",
        success: function (data) {
            // var teachertable = $('#teachertable');
            var tdata;
           
            $.each(data, function (k, v) {
                //  teachertable.append('<option value="' + v.TeacherName + '">' + v.TeacherEmail + '</option>');
                
                tdata += "<tr><td>" + v.TeacherName + "</td><td>" + v.TeacherEmail + "</td><td>" + v.TeacherPhone + "</td></tr>";
                /*$.each(v, function (k, col) {
                    console.log(JSON.stringify(col))
                    tdata += "<tr><td>" + col.TeacherName + "</td><td>" + col.TeacherEmail + "</td><td>" + col.TeacherPhone + "</td></tr>";
                //console.log(JSON.stringify(tdata));
                });*/
            });
            $("#teachertable").append(tdata);
        }
    });
}
