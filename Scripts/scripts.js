function odjava(idRazlog) {

    let odmik = document.cookie.indexOf("UserId") + 7;
    let userId = document.cookie.substring(odmik);
    odmik = userId.indexOf(";");
    if(odmik != -1) userId = userId.substring(0, odmik);


    odmik = document.cookie.indexOf("LocationId") + 11;
    let locationId = document.cookie.substring(odmik);
    odmik = locationId.indexOf(";");
    if (odmik != -1) locationId = locationId.substring(0, odmik);

    console.log(userId);
    console.log(locationId);

    let obj = {
        "IdUsers": userId,
        "IdLocations": locationId,
        "IdLogType": idRazlog
    }

    let url = "/api/log";

    $.ajax({
        type: "POST",
        url: url,
        data: obj,
        success: function (data) {
            window.location.href = '/logiranje/uspeh'
        },
        error: function(err) {
            alert("Prislo je do napake, poskusite ponovno!");
            console.log(err);
        }
    });
}




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


        let url = "/api/user/generate";

        let id;

        $.ajax({
            type: "POST",
            url: url,
            data: obj,
            success: function (data) {
                let d = new Date();
                d.setTime(d.getTime() + (3650 * 24 * 60 * 60 * 1000));
                document.cookie = "UserId=" + data["IdUsers"] + "; expires=" + d + "; path=/";
                document.cookie = "UserName=" + data["Name"] + " " + data["LastName"] + "; expires=" + d + "; path=/";

                let odmik = document.cookie.indexOf("LocationId") + 11;
                // odmik je 10, ker zgornja funkcije vrne -1 in na koncu dodamo 11
                if (odmik == 10) window.location.href = "/";
                else {
                    let locationId = document.cookie.substring(odmik);
                    odmik = locationId.indexOf(";");
                    if (odmik != -1) locationId = locationId.substring(0, odmik);

                    window.location.href = "/logiranje/dodaj/" + locationId;
                }
            },
            error: function (err) {
                alert("Prislo je do napake, poskusite ponovno!");
                console.log(err)
            }
        });
    }
})

$("#odjavaMalica").click(function () {
    odjava(1);
})
$("#odjavaKonec").click(function () {
    odjava(3);
})
$("#odjavaSluzbeni").click(function () {
    odjava(2);
})

