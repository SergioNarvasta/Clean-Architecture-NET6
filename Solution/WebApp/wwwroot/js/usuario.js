
$(document).ready(function () {
    
    getList();

    $("#btnShowCreateModal").on('click', function () {
        $("#createEventModal .titleModal").text('Nuevo Usuario');
        $("#createEventModal #btnCreateEvent").show();
        $("#createEventModal #btnUpdateEvent").hide();
        $("#createEventModal").modal('show');
    });
    $("#btnCreateEvent").on('click', function () {
        createEvent();
    });

    $("#btndeleteEvent").on('click', function () {
        deleteEvent($("#DeleteId").val());
    })

    $("#btnUpdateEvent").on('click', function () {
        updateEvent();
    });
});

function getList() {
    $.ajax({
        url: "/Usuario/GetList",
        type: "GET",
        dataType: "json",
        success: function (data) {
            var usuariosTable = $("#usuariosTable");
            usuariosTable.empty();
            $.each(data, function (index, usuario) {
                var fechaNac = new Date(parseInt(usuario.fechaNac.substr(6))).toLocaleDateString("es-ES");
                var estadoBadgeClass = usuario.estado == 1 ? 'badge bg-success' : 'badge bg-danger';
                var estadoBadgeText = usuario.estado == 1 ? 'Activo' : 'Inactivo';

                var editButton = "<a style='cursor:pointer' onclick='getById(" + usuario.id + ")'  title='Editar'><i class='fas fa-pencil-alt'></i></a>";
                var deleteButton = "<a style='cursor:pointer' onclick=showDeleteEventModal(" + usuario.id + ")  title='Eliminar'><i style='color:red' class='fas fa-trash-alt'></i></a>";

                var row = "<tr>" +
                    "<td>" + usuario.nombres + "</td>" +
                    "<td>" + usuario.apellidos + "</td>" +
                    "<td>" + usuario.dni + "</td>" +
                    "<td>" + fechaNac + "</td>" +
                    "<td><span class='md " + estadoBadgeClass + "'>" + estadoBadgeText + "</span></td>" +
                    "<td>" + editButton + " " + deleteButton + "</td>" +
                    "</tr>";

                usuariosTable.append(row);
            });

        },
        error: function (xhr, status, error) {

        }
    });
}

function createEvent() {
    ClearModal();

   $.ajax({
       type: 'POST',
       url: "/Usuario/Create",
       data: {
           Nombres: $('#Nombres').val(),
           Apellidos: $('#Apellidos').val(),
           DNI: $('#DNI').val(),
           FechaNac: $('#FechaNac').val(),
           RolId: parseInt($('#cboRolList').val()),
           Estado: parseInt($('#cboEstado').val())
       },
       success: function (response) {
           if (response) {
               toastr.success("Se registro con exito!");
               getList();
               $("#createEventModal").modal('hide');
           } else {
               toastr.error("Ocurrio un error!");
           } 
       },
       error: function (xhr, status, error) {
           toastr.error("Ocurrio un error!");
       }
   });
    
}

function getById(id) {
    if (id != null) {
        $.ajax({
            type: 'GET',
            url: "/Usuario/GetById",
            data: {
                usuarioId: id
            },
            success: function (data) {
                var fechaNac = data.fechaNac.split('T')[0]; 
                
                $("#createEventModal #btnCreateEvent").hide();
                $("#createEventModal #btnUpdateEvent").show();
                $("#createEventModal .titleModal").text('Edicion de Usuario');

                $("#createEventModal #UsuarioId").val(data.id);
                $('#createEventModal #Nombres').val(data.nombres);
                $('#createEventModal #Apellidos').val(data.apellidos);
                $('#createEventModal #DNI').val(data.dni);
                $('#createEventModal #FechaNac').val(fechaNac);
                $('#createEventModal #cboEstado').val(data.estado);
                $("#createEventModal").modal('show');
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    }
}

function updateEvent() {
    
    $.ajax({
        type: 'POST',
        url: "/Usuario/Update",
        data: {
            Id: $("#UsuarioId").val(),
            Nombres: $('#Nombres').val(),
            Apellidos: $('#Apellidos').val(),
            DNI: $('#DNI').val(),
            FechaNac: $('#FechaNac').val(),
            Estado: parseInt($('#cboEstado').val())
        },
        success: function (response) {
            if (response) {
                toastr.success("Se actualizo con exito!");
                getList();
                $("#createEventModal").modal('hide');
            } else {
                toastr.error("Ocurrio un error!");
            }
        },
        error: function (xhr, status, error) {
            toastr.error("Ocurrio un error!");
        }
    });

}

function deleteEvent(id) {
    if (id != null) {
        $.ajax({
            type: 'POST',
            url: "/Usuario/Delete",
            data: {
                usuarioId: id
            },
            success: function (response) {
                if (response) {
                    toastr.success("Se elimino con exito!");
                    getList();
                    $("#deleteEventModal").modal('hide');
                } else {
                    toastr.error("Ocurrio un error!");
                }
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    }
}

function showDeleteEventModal(id) {
    $("#deleteEventModal #DeleteId").val(id);
    $("#deleteEventModal").modal('show');
}
function ClearModal() {
    $("#createEventModal #UsuarioId").val("");
    $('#createEventModal #Nombres').val("");
    $('#createEventModal #Apellidos').val("");
    $('#createEventModal #DNI').val("");
    $('#createEventModal #FechaNac').val("");
    $('#createEventModal #cboEstado').val("");
}