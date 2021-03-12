
$("#inputButton").click(function () {
    let name = $("#nameInput").val();
    let lastName = $("#surnameInput").val();

    if (name.length == 0 || lastName.length == 0) {
        alert("Vpisite ime in priimek!");
    } else {

        let obj = {
            "Name": name,
            "LastName": lastName
        }


        let url = "https://localhost:44344/api/user/generate";

        let id;

        $.ajax({
            type: "POST",
            url: url,
            data: obj,
            success: function (data) {
                var d = new Date();
                d.setTime(d.getTime() + (3650 * 24 * 60 * 60 * 1000));
                document.cookie = "UserId=" + data + "; expires=" + d + "; path=/";
                window.location.href = '/'
                
            },
            error: function () {
                alert("Prislo je do napake, poskusite ponovno!");
            }
        });
    }
})