
$(document).ready(function () {
    
    getList();

    $("#btnShowCreateModal").on('click', function () {
        $("#createEventModal .titleModal").text('Nuevo evento');
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
        url: "/Evento/GetList",
        type: "GET",
        dataType: "json",
        success: function (data) {
            var eventosTable = $("#eventosTable");
            eventosTable.empty();
            $.each(data, function (index, evento) {
                var fecha = new Date(parseInt(evento.fecha.substr(6))).toLocaleDateString("es-ES");
                var estadoBadgeClass = evento.estado == 1 ? 'badge bg-success' : 'badge bg-danger';
                var estadoBadgeText = evento.estado == 1 ? 'Activo' : 'Inactivo';

                var editButton = "<a style='cursor:pointer' onclick='getById(" + evento.id + ")'  title='Editar'><i class='fas fa-pencil-alt'></i></a>";
                var deleteButton = "<a style='cursor:pointer' onclick=showDeleteEventModal(" + evento.id + ")  title='Eliminar'><i style='color:red' class='fas fa-trash-alt'></i></a>";

                var row = "<tr>" +
                    "<td>" + evento.nombre + "</td>" +
                    "<td>" + fecha + "</td>" +
                    "<td>" + evento.duracion + "</td>" +
                    "<td>" + evento.nroParticipantes + "</td>" +
                    "<td>" + evento.nroComisarios + "</td>" +
                    "<td><span class='md " + estadoBadgeClass + "'>" + estadoBadgeText + "</span></td>" +
                    "<td>" + editButton + " " + deleteButton + "</td>" +
                    "</tr>";

                eventosTable.append(row);
            });

        },
        error: function (xhr, status, error) {

        }
    });
}

function createEvent() {
    
   $.ajax({
       type: 'POST',
       url: "/Evento/Create",
       data: {
           Nombre: $('#Nombre').val(),
           Fecha: $('#Fecha').val(),
           Duracion: parseInt($('#Duracion').val()),
           NroParticipantes: parseInt($('#NroParticipantes').val()),
           NroComisarios: parseInt($('#NroComisarios').val()),
           UsuarioId: parseInt($('#cboUsuarioList').val()),
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
            url: "/Evento/GetById",
            data: {
                eventoId: id
            },
            success: function (data) {
                var fecha = data.fecha.split('T')[0]; 
                
                $("#createEventModal #btnCreateEvent").hide();
                $("#createEventModal #btnUpdateEvent").show();
                $("#createEventModal .titleModal").text('Edicion de evento');

                $("#createEventModal #EventoId").val(data.id);
                $('#createEventModal #Nombre').val(data.nombre);
                $('#createEventModal #Duracion').val(data.duracion);
                $('#createEventModal #NroComisarios').val(data.nroComisarios);
                $('#createEventModal #NroParticipantes').val(data.nroParticipantes);
                $('#createEventModal #Fecha').val(fecha);
                $('#createEventModal #cboUsuarioList').val(data.usuarioId);
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
        url: "/evento/Update",
        data: {
            Id: $("#EventoId").val(),
            Nombre: $('#Nombre').val(),
            Fecha: $('#Fecha').val(),
            Duracion: parseInt($('#Duracion').val()),
            NroParticipantes: parseInt($('#NroParticipantes').val()),
            NroComisarios: parseInt($('#NroComisarios').val()),
            UsuarioId: parseInt($('#cboUsuarioList').val()),
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
            url: "/Evento/Delete",
            data: {
                eventoId: id
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