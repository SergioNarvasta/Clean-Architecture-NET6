
$(document).ready(function () {
    
    getListRol();

    $("#btnShowCreateRolModal").on('click', function () {
        $("#createRolEventModal .titleModal").text('Nuevo Rol');
        $("#createRolEventModal").modal('show');
    });

    $("#btnCreateRolEvent").on('click', function () {
        createRolEvent();
    });
});

function getListRol() {
    $.ajax({
        url: "/Rol/GetList",
        type: "GET",
        dataType: "json",
        success: function (data) {
            var rolTable = $("#rolTable");
            rolTable.empty();
            $.each(data, function (index, rol) {
               
                var estadoBadgeClass = rol.estado == 1 ? 'badge bg-success' : 'badge bg-danger';
                var estadoBadgeText = rol.estado == 1 ? 'Activo' : 'Inactivo';
                
                var row = "<tr>" +
                    "<td>" + rol.nombre + "</td>" +
                    "<td><span class='md " + estadoBadgeClass + "'>" + estadoBadgeText + "</span></td>" +
                    "</tr>";

                rolTable.append(row);
            });

        },
        error: function (xhr, status, error) {

        }
    });
}

function createRolEvent() {
    
   $.ajax({
       type: 'POST',
       url: "/Rol/Create",
       data: {
           Nombre: $('#RolNombres').val(),
           Estado: parseInt($('#cboRolEstado').val())
       },
       success: function (response) {
           if (response) {
               getListRol();
               toastr.success("Se registro con exito!");
               
           } else {
               toastr.error("Ocurrio un error!");
           } 
       },
       error: function (xhr, status, error) {
           toastr.error("Ocurrio un error!");
       }
   });
    
}
