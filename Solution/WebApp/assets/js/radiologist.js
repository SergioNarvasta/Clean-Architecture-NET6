
$(window).on("load", function () {
    var id = $("#IdCenterSelected").val();
    ListRadiologist(id);
    let radiologistIdDefault = 2;
    displayCalendar(radiologistIdDefault, id); //Instanciar el calendario
});

function showInfoRadiologist() {
    let radiologistId = $("#CboRadiologist").val();
    let centerId = $("#IdCenterSelected").val();
    if (radiologistId > 0) {
        displayCalendar(radiologistId, centerId);
        $("#calendar").show();
    }
}

function ListRadiologist(id) {

    $.ajax({
        type: 'POST',
        url: "/RadiologistSchedule/GetRadiologist",
        data: { centerid: id },
        success: function (data) {
            var dropdownList = $('<select/>', {
                id: 'CboRadiologist',
                name: 'CboRadiologist',
                class: 'form-select',
                onchange: 'showInfoRadiologist()'
            });

            $.each(data, function (index, item) {
                dropdownList.append($('<option/>', {
                    value: item.Id,
                    text: item.FullName
                }));
            });

            $('#divRadiologist').html('').append(dropdownList);
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });
}

function displayCalendar(radiologistId, centerId) {
    var calendarEl = document.getElementById('calendar');
    $("#calendar").empty();
    calendar = new FullCalendar.Calendar(calendarEl, {
        plugins: ["bootstrap", "interaction", "dayGrid", "timeGrid"],
        editable: true,
        droppable: true,
        selectable: true,
        defaultView: "timeGridWeek",
        themeSystem: "bootstrap",
        allDaySlot: false,
        header: { left: "today", center: "title", right: "prev,next" },
        headerToolbar: {
            left: 'today',
            center: 'title',
            right: 'prev,next'
        },
        firstDay: 1,
        slotDuration: '00:30:00',
        slotLabelInterval: 30,
        slotMinutes: 30,
        locale: 'es',
        events: {
            url: '/RadiologistSchedule/GetScheduledRadiologist',
            extraParams: {
                centerId: centerId,
                radiologistId: radiologistId
            }
        },
        slotLabelFormat: { // like '14:30:00'
            hour: '2-digit',
            minute: '2-digit',
            meridiem: 'short'
        },
        selectConstraint: null,
        selectAllow: function (selectInfo) {
            var currentDate = new Date();
            var selectedDate = selectInfo.start;
            if (selectedDate < currentDate) {
                return false; // Bloquea la selección de eventos pasados
            }
            return true; // Permite la selección para eventos futuros
        },
        dayRender: function (info) {
            let today = new Date().setHours(0, 0, 0, 0);
            var currentDay = info.date.setHours(0, 0, 0, 0);
            if (currentDay === today) {
                info.el.style.backgroundColor = '#ffff99';
            }
        },

        /*eventContent: function (info) {
            var eventTitle = document.createElement('div');
            eventTitle.classList.add('fc-title');
            eventTitle.innerText = info.event.title;

            return {
                domNodes: [eventTitle]
            };
        }, */
        minTime: '@ViewBag.CenterStartTime',
        maxTime: '@ViewBag.CenterEndTime',
        height: 'auto',
        selectOverlap: function (event) {
            return event.rendering === 'inverse-background';
        },
        eventClick: function (event, jsEvent, view) {
            var endTime = $.fullCalendar.moment(event.end).format('h:mm a');
            var startTime = $.fullCalendar.moment(event.start).format('dddd,  MMMM Do YYYY, h:mm a');
            var centerSelected = $("#CenterId option:selected").text();
            $('#deleteSchedulerEventModal #Date').text(startTime + " - " + endTime);
            $('#deleteSchedulerEventModal #eventID').val(event.id);
            $('#deleteSchedulerEventModal').modal();
        },
        select: function (info) {
            let date = moment(info.start).format('dddd D [de] MMMM YYYY');
            let startTime = moment(info.start).format('h:mm a');
            let endTime = moment(info.end).format('h:mm a');
            $('#createSchedulerEventModal #TextoFecha').text("Fecha: " + date);
            $('#createSchedulerEventModal #RangoFecha').text("Rango de horas: " + startTime + " hasta las " + endTime);
            $('#createSchedulerEventModal').modal('show');
        },
        eventDrop: function (event, delta) {
            var eventId = event.id;
            var startDate = moment(event.start).format();
            var endDate = moment(event.end).format();
            updateEvent(eventId, startDate, endDate);
        },
        eventResize: function (event) {
            var eventId = event.id;
            var startDate = moment(event.start).format();
            var endDate = moment(event.end).format();
            updateEvent(eventId, startDate, endDate);
        }
    });
    calendar.on('datesRender', function () {
        /*var eventElements = document.getElementsByTagName('div');

        var filteredElements = Array.from(eventElements).filter(function (element) {
            return element.classList.contains('fc-bgevent');
        });

        console.log(filteredElements);
        console.log("filteredElements " + filteredElements.length);

        filteredElements.forEach(function (element, index) {
            let events = calendar.getEvents();
            if (index < events.length) {
                let event = events[index];
                let title = event.title;
                element.innerHTML = title;
                console.log("title", title);
            }
        });*/
    });
    calendar.render();
}

