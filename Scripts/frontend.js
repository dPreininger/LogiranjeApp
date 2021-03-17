$("#user-pic").click(function () {
    $("#user-info-signed").removeClass("hidden");
})
$("body").click(function (e) {
    if (!e.target.classList.contains("no-close")) {
        $("#user-info-signed").addClass("hidden");
    }
});