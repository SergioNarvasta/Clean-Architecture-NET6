$("#btnShowModalLogin").on('click', function () {
    $("#loginEventModal").modal('show');
});

$("#btnLoginEvent").on('click', function () {
    $("#messageError").hide();

    let usuario = $('#txtUsuarioLogin').val();
    let clave = $('#txtContraseñaLogin').val();
    if (usuario.length > 0 && clave.length) {
        $.ajax({
            type: 'POST',
            url: "/Acceso/IniciarSesion",
            data: {
                Usuario: usuario,
                Clave: clave
            },
            success: function (response) {
                console.log(response);
                if (response != null) {
                    window.location.reload();
                } else {
                    mostrarError("Usuario y/o contraseña incorrectos");
                }
            },
            error: function (xhr, status, error) {
                toastr.error("Ocurrio un error!");
            }
        });

    } else {
        mostrarError("Complete los campos");
    }
    
}); 

$("#btnLogout").on('click', function () {
   $.ajax({
       type: 'POST',
       url: "/Acceso/CerrarSesion",
       success: function (response) {     
           window.location.reload();
       },
       error: function (xhr, status, error) {
           toastr.error("Ocurrio un error!");
       }
   });
});

function mostrarError(mensaje) {
    $("#messageError").text(mensaje);
    $("#messageError").show();
}