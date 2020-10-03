$(document).ready(function () {
    //alert("Courseinfo js load");
   // $("#MyDataTable").DataTable();
    GetEmployeeRecord();
});

function GetEmployeeRecord () {

    $.ajax({

        type: "Get",
        url: "/CourseInfo/GetEmployeeRecord",
        success: function (response) {
           // console.log(JSON.stringify(response));
            BindDataTable(response);
          
        }
    })

}


function BindDataTable(response) {

    $("#MyDataTable").DataTable({

        "aaData": response,
        "aoColumns": [

            { "mData": "CourseName" },
            { "mData": "CourseCredit" },
           // { "mData": "CourseId" },
            {
                "mData": "CourseId",
                "render": function (CourseId, type, full, meta) {
                    //debugger
                    return '<a href="#" onclick="AddEditCourse(' + CourseId + ')"><i class="glyphicon glyphicon-pencil"></i></a>'
                }
            },
          
        ]

    });
}

function AddEditCourse(employeeId) {

    var url = "/CourseInfo/AddEditEmployee?CourseId=" + CourseId;

    $("#myModalBodyDiv1").load(url, function () {
        $("#myModal1").modal("show");

    })

}