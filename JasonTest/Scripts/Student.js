$(document).ready(function () {

    alert("Load student js");
});

function SaveData() {
    var name = $("#Name").val();
    var roll = $("#Roll").val();
    var address = $("#Address").val();

    if (name == null || name == "") {
        alert("Insert Name ..");
        return;
    }
    if (roll == null || roll == "") {
        alert("Insert Roll ..");
        return;
       
    }
    if (address == null || address == "") {
        alert(" Insert Address ..");
        return;
    }

    $.ajax({
        type: "POST",
        url: "../Home/CreateStudent",
        data: {
            StudentName: name,
            Role: roll,
            Address: address,
        },
        success: function (data) {
            alert("Data Insert..")
        }


    });
}
