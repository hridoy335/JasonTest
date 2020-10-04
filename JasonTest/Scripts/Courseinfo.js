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

function AddCourse() {
    var url = "../CourseInfo/AddCourseInfo"

    $("#myModalBodyDiv").load(url, function () {
        $("#myModal").modal("show");
    })

}

function addCourse() {
//  var myformdata = $("#myForm").serialize();

    var name = $("#Name").val();
    var credit = $("#Credit").val();
    console.log(JSON.stringify(name));


    $.ajax({
        type: "POST",
        url: "../CourseInfo/CoueseCreate",
        data: {
            CourseName: name,
            CourseCredit: credit
           
        },
        success: function (data) {
            alert("Insert Teacher Data ...");
            $("#loaderDiv").hide();
            $("#myModal").modal("hide");
            window.location.href = "/CourseInfo/index";
        }


    });

    //$.ajax({

    //    type: "POST",
    //    url: "/CourseInfo/CoueseCreate",
    //    data: myformdata,
    //    success: function () {
    //        $("#loaderDiv").hide();
    //        $("#myModal").modal("hide");
    //        window.location.href = "/CourseInfo/index";

    //    }

    //})


}