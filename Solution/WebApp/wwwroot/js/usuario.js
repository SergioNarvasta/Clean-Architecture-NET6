

var dataTable;

$(document).ready(function () {
    dataTable = $("#usuariosTable").DataTable({
        "ajax": {
            "url": "/Usuario/GetList",
            "type": "GET",
            "datatype": "json"
        },
        "language": {
            "url": '/assets/lang/es-datatable.json'
        },
        "lengthChange": false,
        "columns": [
            { "data": "Nombres" },
            { "data": "Apellidos" },
            { "data": "DNI" },
            {
                "data": "FechaNac",
                "render": function (data) {
                    var date = new Date(parseInt(data.substr(6)));
                    return date.toLocaleDateString("es-ES");
                }
            },    
            {
                "data": "Estado",
                "render": function (data) {
                    var badgeClass = data == 1 ? 'badge bg-success' : 'badge bg-danger';
                    var badgeText = data == 1 ? 'Activo' : 'Inactivo';
                    return '<span class=" md ' + badgeClass + '">' + badgeText + '</span>';
                }
            },
            {
                "data": "Id",
                "render": function (data, type, row) {
                    var editButton = "<a onclick='getRateById(" + data + ")' class='btn btn-info btn-sm' title='Editar'><i class='fas fa-pencil-alt'></i></a>";
                    var deleteButton = "<a href='#' onclick=showDeleteRateEventModal(" + data + ") class='btn btn-danger btn-sm' title='Eliminar'><i class='fas fa-trash-alt'></i></a>";

                    return editButton + " " + deleteButton;
                },
                "orderable": false,
                "searchable": false
            }
        ]
    });

    $("#btnShowCreateModal").on('click', function () {
        $("#createEventModal .titleModal").text('Nuevo Usuario');
        $("#createEventModal #btnCreateEvent").show();
        $("#createEventModal #btnUpdateEvent").hide();
        //clearCreateModal();
        $("#createEventModal").modal('show');
    });
});