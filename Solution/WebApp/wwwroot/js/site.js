$("#btnShowModalLogin").on('click', function () {
    $('#txtContraseñaLogin').val("");
    $("#loginEventModal").modal('show');
});

$("#btnRegistroEvent").on('click', function () {
    $("#loginEventModal").modal('hide');
    $("#createSesionEventModal").modal('show');
});

$("#btnCreateSesionEvent").on('click', function () {
   
    $.ajax({
        type: 'POST',
        url: "/Acceso/CrearSesion",
        data: {
            Nombres: $('#RegNombres').val(),
            Apellidos: $('#RegApellidos').val(),
            DNI: ($('#RegDNI').val()),
            FechaNac: ($('#RegFechaNac').val()),
            Usuario: ($('#RegUsuarioName').val()),
            Clave: ($('#RegContraseña').val()),
            Estado: 1
        },
        success: function (response) {
            if (response) {
                toastr.success("Se registro con exito!");
              
                $("#createSesionEventModal").modal('hide');
            } else {
                toastr.error("Ocurrio un error!");
            }
        },
        error: function (xhr, status, error) {
            toastr.error("Ocurrio un error!");
        }
    });
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
           window.location.href = "/";
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