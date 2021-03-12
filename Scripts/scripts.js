
$("#inputButton").click(function () {
    let name = $("#nameInput").val();
    let lastName = $("#surnameInput").val();

    let obj = {
        "Name": name,
        "LastName": lastName
    }

    console.log(obj);

    let url = "https://localhost:44344/api/user/generate";

    let id;

    $.ajax({
        type: "POST",
        url: url,
        data: obj,
        success: function (data, textStatus, jqXHR) {
            var d = new Date();
            d.setTime(d.getTime() + (3650 * 24 * 60 * 60 * 1000));
            document.cookie = "UserId=" + data + "; expires=" + d + "; path=/";
            window.location.href = '/'
        }
    });
})