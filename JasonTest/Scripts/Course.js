$(document).ready(function () {
    alert("Course js load");

    //$(document).ready(function () {

    // $("#MyDataTable").DataTable();

    GetEmployeeRecord();
});

function GetEmployeeRecord() {


    $.ajax({

        type: "Get",
        url: "../Course/GetEmployeeRecord",
        success: function (response) {

           // console.log(JSON.stringify(response));
          // BindDataTable(response);
            var sdata;
            $.each(response, function (k, v) {
                sdata += "<tr><td>" + v.CourseName + "</td><td>" + v.CourseCredit + "</td><td>" + "<a href='EditCourse/"+ v.CourseId +"'>Edit</a>"+ "</td></tr>";

               
               
            
            })
            $("#MyDataTable").append(sdata);

        }
    })



}

function BindDataTable(response) {

    $("#MyDataTable").DataTable({

        aaData: response,
        aoColumns: [

            { "mData": response.CourseName },
            { "mData": response.CourseCredit },
      
            //{
            //    "mData": response.CourseId,
            //    "render": function (CourseId, type, full, meta) {
            //        debugger
            //        return '<a href="#" onclick="AddEditEmployee(' + CourseId + ')"><i class="glyphicon glyphicon-pencil"></i></a>'
            //    }
            //},


        ]

    });
  }
    
