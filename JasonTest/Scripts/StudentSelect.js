$(document).ready(function () {
    alert("Student Select JS Load");

    studentList();
});

function studentList() {

    $.ajax({
        type: "GET",
        url: "../Home/viewStudent",
        success: function (data) {
            var sdata;
            $.each(data, function (k, v) {
                sdata += "<tr><td>" + v.StudentName + "</td><td>" + v.Role + "</td><td>" + v.Address + "</td></tr>";
                

            })
            $("#Studenttable").append(sdata);
        }
    });
}