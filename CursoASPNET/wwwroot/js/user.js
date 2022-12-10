$('form').on('submit', function (event) {
    event.preventDefault();

    var formData = {
        "id": $("#UserId").val(),
        "password": $("#password").val(),
        "ConfirmPassword": $("#confirmPassword").val(),
        "personId": $("#PersonId").val(),
        "person": {
            "id": $("#PersonId").val(),
            "username": $("#username").val(),
            "email": $("#email").val()
        }    
    }

    $.ajax({
        type: "PATCH",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        data: JSON.stringify(formData),
        url: "https://localhost:44394/api/user/update",
        success: function (result) {
            if (result.response == 'OK')
                alert("Salvo so sucesso")
           
        },
        error: function (error) {
            console.log(error);
        }
    })
});