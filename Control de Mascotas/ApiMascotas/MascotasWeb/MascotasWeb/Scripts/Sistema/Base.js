let getUrl = window.location;
//let base_url = getUrl.protocol + "//" + getUrl.host + "/" + getUrl.pathname.split('/')[1]; // Produ
let base_url = getUrl.protocol + "//" + getUrl.host;
let numeroPaginacionDisponible = 10;

let General = function () {

    // Función que permite mostrar mensajes de error.
    this.MostrarMensaje = function (tipo, titulo, mensaje, objetoError, objetoExito) {

        // Devuelve la estructura del mensaje a retornar.
        let estructura = obtenerEstructuraMensaje(titulo, mensaje, tipo);
        let callbackManual = false;
        let botones = {};

        // Defino las funciones de callback;
        let funcionPositiva = function () { };
        let funcionNegativa = function () { };

        // Si el mensaje de error va a ser personalizado.
        if (objetoError) {
            estructura.dangerMode = true;

            botones.cancel = {
                text: objetoError.titulo,
                value: false,
                visible: true,
                className: "",
                closeModal: true
            };

            // Función de error del callback.
            if (objetoError.callback) {
                callbackManual = true;
                funcionNegativa = objetoError.callback;
                estructura.closeOnClickOutside = false;
            }
        }

        // Si el mensaje de éxito va a ser personalizado.
        if (objetoExito) {

            botones.confirm = {
                text: objetoExito.titulo,
                value: true,
                visible: true,
                className: "",
                closeModal: objetoExito.callback ? false : true
            };

            // Función de éxito del callback.
            if (objetoExito.callback) {
                callbackManual = true;
                funcionPositiva = objetoExito.callback;
                estructura.closeOnClickOutside = false;
            }
        }

        // Función de retorno del evento.
        let funcionRetorno = function (esCorrecto) {
            let resultado;

            if (esCorrecto)
                resultado = funcionPositiva();
            else
                resultado = funcionNegativa();

            if (resultado)
                swal.close();

            return resultado;
        };

        // Verifica si se pinto algún boton.
        if (Object.keys(botones).length > 0)
            estructura.buttons = botones;

        // Si se definió una función de callback se hace el llamado.
        if (callbackManual)
            swal(estructura).then(funcionRetorno);
        else
            swal(estructura);
    }

    // Obtener el tipo de error.
    function obtenerTipoError(tipoMensaje) {
        switch (tipoMensaje) {
            case "E":
                return "error";
            case "I":
                return "success";
            case "A":
                return "warning";
            default:
                return "";
        }
    }

    // Obtener la estructura base de los mensajes.
    function obtenerEstructuraMensaje(titulo, mensaje, tipo) {
        return {
            title: titulo,
            text: mensaje,
            icon: obtenerTipoError(tipo)
        };
    }

    // Función que genera la tabla del sistema.
    this.GenerarTabla = function (nombreTabla, propiedades) {
        let tablaSistema;

        propiedades = obtenerPropiedadesTabla(propiedades);

        tablaSistema = $("#" + nombreTabla).DataTable(propiedades);

        // Habilita los botones de editar y eliminar
        tablaSistema.on('select', function (e, dt, type, indexes) {
            if (type === 'row') {
                $("#acciones #Editar").removeClass("disabled");
                $("#acciones #Eliminar").removeClass("disabled");
            }
        });

        // Deshabilita los botones de editar y eliminar
        tablaSistema.on('deselect', function (e, dt, type, indexes) {
            if (type === 'row') {
                $("#acciones #Editar").addClass("disabled");
                $("#acciones #Eliminar").addClass("disabled");
            }
        });

        return tablaSistema;
    }

    // Función que permite obtener todas las propiedades de la tabla.
    function obtenerPropiedadesTabla(propiedades) {
        let propiedadesFinales = {};
        let propiedadesBase = {
            "processing": true,
            "serverSide": true,
            "orderMulti": false,
            "pageLength": numeroPaginacionDisponible,
            "language": idioma_espanol,
            "dom": '<"top"lf>rt<"bottom"ip><"clear">',
            "select": {
                style: 'single'
            }
        };

        $.extend(true, propiedadesFinales, propiedadesBase, propiedades);
        return propiedadesFinales;
    }

    // Función que permite generar el calendario.
    this.GenerarCalendario = function(listaCampos){
        for (let i = 0; i < listaCampos.length; i++) {
            $("#" + listaCampos[i]).datepicker({
                changeMonth: true,
                changeYear: true,
                showOtherMonths: true,
                format: 'dd/mm/yyyy',
                dateFormat: "dd/mm/yy",
                dayNamesShort: $.datepicker.regional["es"].daysShort,
                dayNames: $.datepicker.regional["es"].dayNames,
                dayNamesMin: $.datepicker.regional["es"].daysMin,
                monthNamesShort: $.datepicker.regional["es"].monthsShort,
                monthNames: $.datepicker.regional["es"].months
            });
        }
    }
}

let general = new General();