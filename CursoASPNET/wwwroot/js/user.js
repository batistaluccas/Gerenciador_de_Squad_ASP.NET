$('form').on('submit', function (event) {
    event.preventDefault();

    var formData = {
        "id": $("#UserId").val(),
        "password": $("#password").val(),
        "ConfirmPassword": $("#confirmPassword").val(),
        "personId": $("#PersonId").val(),
        "person": {
            "id": $("#PersonId").val(),
            "username": $("#email").val(),
            "email": $("#email").val()
        }    
    }

    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        data: JSON.stringify(formData),
        url: "https://localhost:44394/api/user",
        success: function (result) {
            if (result.response == 'ERROR')
                alert("credenciais inválidas")
            else {
                let baseUrl = $('#btnLogin').data('baseUrl');
                window.location = baseUrl + "?" +
                    "UserId=" + result.userId +
                    "&PersonId=" + result.personId +
                    "&Username=" + result.username +
                    "&Email=" + result.email;
            }
        },
        error: function (error) {
            console.log(error);
        }
    })
});