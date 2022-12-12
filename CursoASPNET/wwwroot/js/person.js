$('form').on('submit', function (event) {
    event.preventDefault();

    var type = document.getElementById('type').value;

    var formData = {
        "id": $("#Id").val() != "" ? parseInt($("#Id").val()) : 0,
        "name": $("#name").val(),
        "email": $("#email").val(),
        "type": type
    }

    $.ajax({
        type: $("#Id").val() != null && $("#Id").val() != "" ? "PATCH" : "POST",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        data: JSON.stringify(formData),
        url: "https://localhost:44394/api/Person" + ($("#Id").val() != null && $("#Id").val() != "" ? "/update" : "/create"),
        success: function (result) {
            if (result.response == 'OK')
                alert("Salvo so sucesso")

        },
        error: function (error) {
            console.log(error);
        }
    })
});