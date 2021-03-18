
function getUserName(id) {

    let url = "/api/user/" + id;


    $.ajax({
        type: "GET",
        url: url,
        async: false,
        success: function (data) {
            let d = new Date();
            d.setTime(d.getTime() + (3650 * 24 * 60 * 60 * 1000));
            document.cookie = "UserName=" + data["Name"] + " " + data["LastName"] + "; expires=" + d + "; path=/";
        }
    });
}


$("#user-pic").click(function () {
    let odmik = document.cookie.indexOf("UserId") + 7;
    if (odmik > 6) {
        let userId = document.cookie.substring(odmik);
        odmik = userId.indexOf(";");
        if (odmik != -1) userId = userId.substring(0, odmik);

        let userName;
        odmik = document.cookie.indexOf("UserName") + 9;
        if (odmik == 8) {
            getUserName(userId);
            odmik = document.cookie.indexOf("UserName") + 9;
        }
        userName = document.cookie.substring(odmik);
        odmik = userId.indexOf(";");
        if (odmik != -1) userId = userName.substring(0, odmik);

        $('#menu-id').text(userId);
        $('#menu-user').text(userName);

        $("#user-info-signed").removeClass("hidden");
    } else {
        $("#user-info-unsigned").removeClass("hidden");
    }


    $("#arrow-right").removeClass("hidden");
    $("#arrow-left").removeClass("hidden");
});
$("body").click(function (e) {
    if (!e.target.classList.contains("no-close")) {
        $("#user-info-signed").addClass("hidden");
        $("#user-info-unsigned").addClass("hidden");
        $("#arrow-right").addClass("hidden");
        $("#arrow-left").addClass("hidden");
    }
});
