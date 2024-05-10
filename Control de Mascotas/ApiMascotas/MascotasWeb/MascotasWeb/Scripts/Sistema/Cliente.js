(() => {
    'use strict'

    let tabla;

    $(document).ready(function () {
        InicializarDataTable("tablaClientes");
        InicializarAcciones();
    });

    function InicializarDataTable(nombreTabla) {

        let propiedades = {
            "ajax": {
                "url": base_url + "/Cliente/CargarDatos",
                "type": "POST",
                "datatype": "json"
            },
            "columns": [
                { "data": "Nombre", "name": "Nombre" },
                { "data": "Cedula", "name": "Cedula" },
                { "data": "Telefono", "name": "Telefono" },
                { "data": "Correo", "name": "Correo" },
                {
                    "data": "Mascotas", "name": "Mascotas", "render": function (data, type, full) {
                        let str = "";
                        for (let i = 0; i < data.length; i++)
                            str += data[i] + ((i == data.length - 1) ? "" : ",");
                        return str;
                    }
                },
                { "data": "Direccion", "name": "Direccion" }
            ]
        };

        tabla = general.GenerarTabla(nombreTabla, propiedades);
    }

    // Función que inicializa los eventos de los botones de Agregar, Editar y Eliminar.
    function InicializarAcciones() {

        $("#Agregar").on("click", function () {
            abrirModalCliente(null, "A");
        });

        $("#Editar").on("click", function () {
            let seleccionado = tabla.rows('.selected').data()[0];
            abrirModalCliente(seleccionado, "E");
        });

        $("#Eliminar").on("click", function () {
            let seleccionado = tabla.rows('.selected').data()[0];
            eliminarCliente(seleccionado);
        });
    }

    // Función que abre la información del modal del cliente.
    function abrirModalCliente(cliente, tipo) {

        let titulo = (tipo == "E" ? "Editar" : "Crear") + " cliente";
        let tituloSecundario = (tipo == "E" ? "Edición" : "Creación") + " de cliente";
        let mascotas = "";

        if (tipo == "E") {
            if (cliente != null && cliente.Mascotas != null && cliente.Mascotas.length > 0) {
                for (let i = 0; i < usuario.Paises.length; i++) {
                    mascotas += cliente.Mascotas[i].Nombre + (cliente.Mascotas.length - 1 == i ? "" : ", ");
                }
            } else
                mascotas = "N/A";
        } else
            mascotas = "N/A";

        // Limpia el modal.
        $("#headerModal").empty();
        $("#bodyModal").empty();
        $("#footerModal").empty();

        // Pinto el título del modal.
        $("#headerModal").append
            (
                '<h5 class= "modal-title" id = "exampleModalLongTitle" > ' + titulo + '</h5 >' +
                '<button id="xModal" type="button" class="close" aria-label="Close">' +
                '<span aria-hidden="true">&times;</span>' +
                '</button>'
            );

        let ventana = '<div class="container-fluid">' +
            '<div class="row">' + '<h3>' + tituloSecundario + '</h3>' + '</div>' +
            '<form id="formularioCliente" class="needs-validation" novalidate="">' +
            '<div class="row" >' +
            '<div class="col-sm-6">' +
            '<br/>' +

            '<label for="primerNombre" class="col-form-label">Primer Nombre</label>' +
            '<input type="text" class="form-control" id="primerNombre" maxlength="250" tabindex="0" ' + (tipo == 'E' ? 'disabled' : 'required') + '>' +
            '<label for="primerApellido" class="col-form-label">Primer Apellido</label>' +
            '<input type="text" class="form-control" id="primerApellido" maxlength="250" tabindex="2" ' + (tipo == 'E' ? 'disabled' : 'required') + '>' +
            '</div>' +

            '<div class="col-sm-6">' +
            '<br/>' +

            '<label for="segundoNombre" class="col-form-label">Segundo Nombre</label>' +
            '<input type="text" class="form-control" id="segundoNombre" maxlength="250" tabindex="1" ' + (tipo == 'E' ? 'disabled' : '') + '>' +
            '<label for="segundoApellido" class="col-form-label">Segundo Apellido</label>' +
            '<input type="text" class="form-control" id="segundoApellido" maxlength="250" tabindex="3" ' + (tipo == 'E' ? 'disabled' : 'required') + '>' +
            '</div>' +
            '</div>' +

            '<div class="row">' +
            '<div class="col-sm-6">' +

            '<label for="cedula" class="col-form-label">Cédula</label>' +
            '<input type="text" class="form-control" id="cedula" pattern="^.{11,}$" tabindex="4" ' + (tipo == 'E' ? 'disabled' : 'required') + '>' +
            '<label for="fechaNacimiento" class="col-form-label">Fecha de Nacimiento</label>' +
            '<input type="text" class="form-control" id="fechaNacimiento" maxlength="250" tabindex="6" ' + (tipo == 'E' ? 'disabled' : 'required') + '>' +
            '</div>' +

            '<div class="col-sm-6">' +

            '<label for="telefono" class="col-form-label">Teléfono</label>' +
            '<input type="text" class="form-control" id="telefono" maxlength="250" tabindex="5">' +
            '<label for="sexo" class="col-form-label">Sexo</label>' +
            '<select class="form-select" id="sexo" tabindex="7" required ' + (tipo == 'E' ? 'disabled' : 'required') + '></select>' +
            '</div>' +
            '</div>' +

            '<div class="row">' +
            '<div class="col-sm-12">' +
            '<label for="correo" class="col-form-label">Correo</label>' +
            '<input type="email" pattern="^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$" class="form-control" id="correo" maxlength="255" placeholder="Ingrese su correo" tabindex="8" required>' +
            '</div>' +
            '</div>' +

            '<div class="row">' +
            '<div class="col-sm-4">' +
            '<label for="provincia" class="col-form-label">Provincia</label>' +
            '<select class="form-select" id="provincia" tabindex="9" required></select>' +
            '</div>' +
            '<div class="col-sm-4">' +
            '<label for="canton" class="col-form-label">Canton</label>' +
            '<select class="form-select" id="canton" tabindex="10" required></select>' +
            '</div>' +
            '<div class="col-sm-4">' +
            '<label for="distrito" class="col-form-label">Distrito</label>' +
            '<select class="form-select" id="distrito" tabindex="11" required></select>' +
            '</div>' +
            '</div>' +

            '<div class="row">' +
            '<div class="col-sm-12">' +
            '<label for="direccionExacta" class="col-form-label">Dirección</label>' +
            '<textarea class="form-control" rows="3" id="direccionExacta" maxlength="255" placeholder="Ingrese la dirección exacta" tabindex="12"></textarea>' +
            '</div>' +
            '</div>' +
            '</form>' +
            '</div>';

        $("#bodyModal").append(ventana);

        $("#footerModal").append
            (
                '<button id="cerrarModal" type="button" tabindex="13" class="btn btn-secondary">Cerrar</button>' +
                (tipo == "E" ?
                    '<button type="button" class="btn btn-primary" tabindex="14" onclick="editarCliente(' + (cliente ? cliente.Id : '') + ');">Editar</button>' :
                    '<button type="button" class="btn btn-primary" tabindex="14" onclick="agregarCliente();">Crear</button>'
                )
            );

        $('#modalCliente').modal('show');

        // Evento que se dispara cuando presionó el botón de cerrar.
        $("#cerrarModal").on('click', function () {
            $("#modalCliente").modal('hide');
        });

        // Evento que se dispara cuando se presiona la X.
        $("#xModal").on('click', function () {
            $("#modalCliente").modal('hide');
        });

        // Evento que se dispara cuando se cambie la provincia.
        $("#provincia").on("change", function () {
            let idProvincia = $(this).val();

            if (idProvincia == "-1") {
                $("#canton").empty();
                $("#distrito").empty();
                return;
            }

            obtenerCantones(idProvincia);
            $("#distrito").empty();
        });

        // Evento que se dispara cuando se cambie el cantón.
        $("#canton").on("change", function () {
            let idCanton = $(this).val();
            obtenerDistritos(idCanton);
        });

        // Evento que se dispara cuando se escribe la cédula.
        $("#cedula").on("change", function () {
            let cedula = $("#cedula").val();
            validarCedula(cedula);
        });

        pintarMascaras();
        obtenerSexos();
        obtenerProvincias();
        general.GenerarCalendario(["fechaNacimiento"]);

        // Si está en modo edición.
        if (cliente != null) {
            cargarDatosCliente(cliente.Id);
        }
    }

    // Función que pinta las máscaras con el formato de las máscaras ofrecidas.
    function pintarMascaras() {

        $("#cedula").mask('0-0000-0000', {
            placeholder: "X-XXXX-XXXX"
        });

        $("#telefono").mask('0000-0000', {
            placeholder: "XXXX-XXXX"
        });

        $("#fechaNacimiento").mask('00/00/0000', {
            placeholder: "dd/mm/yyyy"
        });
    }

    // Función que permite cargar la lista de sexos.
    function obtenerSexos() {

        $.ajax({
            type: "GET",
            url: base_url + "/General/ObtenerSexos",
            dataType: "json",
            cache: false,
            success: function (respuesta) {
                if (respuesta && respuesta.sexos && respuesta.sexos.length > 0) {
                    let sexos = respuesta.sexos;
                    repintarComboSexo(sexos);
                }
            }
        });
    }

    // Función que realiza el repintado del combo de sexos.
    function repintarComboSexo(sexos) {

        let comboSexo = $("#sexo");
        comboSexo.empty();
        //comboSexo.append($("<option>", { value: null, text: "" }));

        for (let i = 0; i < sexos.length; i++) {
            let elemento = $("<option>", {
                value: sexos[i].Id,
                text: sexos[i].Nombre
            });
            comboSexo.append(elemento);
        }
    }

    // Función que permite cargar la lista de provincias.
    function obtenerProvincias() {

        $.ajax({
            type: "GET",
            url: base_url + "/General/ObtenerProvincias",
            dataType: "json",
            cache: false,
            success: function (respuesta) {
                if (respuesta && respuesta.provincias && respuesta.provincias.length > 0) {
                    let provincias = respuesta.provincias;
                    repintarComboProvincias(provincias);
                }
            }
        });
    }

    // Función que realiza el repintado del combo de provincias.
    function repintarComboProvincias(provincias) {

        let comboProvincia = $("#provincia");
        comboProvincia.empty();
        comboProvincia.append($("<option>", { value: -1, text: "N/A" }));

        for (let i = 0; i < provincias.length; i++) {
            let elemento = $("<option>", {
                value: provincias[i].IdProvincia,
                text: provincias[i].Nombre
            });
            comboProvincia.append(elemento);
        }
    }

    // Función que permite cargar la lista de cantones.
    function obtenerCantones(idProvincia) {

        $.ajax({
            type: "GET",
            url: base_url + "/General/ObtenerCantones",
            data: {
                "IdProvincia": idProvincia
            },
            dataType: "json",
            cache: false,
            success: function (respuesta) {
                if (respuesta && respuesta.cantones && respuesta.cantones.length > 0) {
                    let cantones = respuesta.cantones;
                    repintarComboCantones(cantones);
                }
            }
        });
    }

    // Función que realiza el repintado del combo de cantones.
    function repintarComboCantones(cantones) {

        let comboCantones = $("#canton");
        comboCantones.empty();
        comboCantones.append($("<option>", { value: null, text: "" }));

        for (let i = 0; i < cantones.length; i++) {
            let elemento = $("<option>", {
                value: cantones[i].IdCanton,
                text: cantones[i].Nombre
            });
            comboCantones.append(elemento);
        }
    }

    // Función que permite validar la cédula (se comprueba si ya existen personas con esa cédula).
    function validarCedula(cedula) {

        $.ajax({
            type: "GET",
            url: base_url + "/General/ValidarCedula",
            data: {
                "Cedula": cedula
            },
            dataType: "json",
            cache: false,
            success: function (respuesta) {
                if (respuesta) {
                    let estado = respuesta.estado;

                    if (estado) {
                        // Limpio la cédula ingresada.
                        $("#cedula").val("");
                        general.MostrarMensaje("E", "Cédula registrada", "Ya existe una persona registrada con esa cédula.");
                        return false;
                    }
                }
            }
        });
    }

    // Función que permite cargar la lista de distritos.
    function obtenerDistritos(idCanton) {

        $.ajax({
            type: "GET",
            url: base_url + "/General/ObtenerDistritos",
            data: {
                "IdCanton": idCanton
            },
            dataType: "json",
            cache: false,
            success: function (respuesta) {
                if (respuesta && respuesta.distritos && respuesta.distritos.length > 0) {
                    let distritos = respuesta.distritos;
                    repintarComboDistritos(distritos);
                }
            }
        });
    }

    // Función que realiza el repintado del combo de distritos.
    function repintarComboDistritos(distritos) {

        let comboDistritos = $("#distrito");
        comboDistritos.empty();
        comboDistritos.append($("<option>", { value: null, text: "" }));

        for (let i = 0; i < distritos.length; i++) {
            let elemento = $("<option>", {
                value: distritos[i].IdDistrito,
                text: distritos[i].Nombre
            });
            comboDistritos.append(elemento);
        }
    }

    // Función que permite cargar los datos del cliente actual.
    function cargarDatosCliente(idCliente) {

        $.ajax({
            type: "GET",
            url: base_url + "/Cliente/Obtener",
            data: {
                "IdCliente": idCliente
            },
            dataType: "json",
            cache: false,
            success: function (respuesta) {
                if (respuesta) {
                    let datosCliente = respuesta;
                    repintarDatosCliente(datosCliente);
                }
            }
        });
    }

    // Función que permite configurar los datos del cliente.
    function repintarDatosCliente(datosCliente) {
        $("#primerNombre").val(datosCliente.PrimerNombre);
        $("#segundoNombre").val(datosCliente.SegundoNombre);
        $("#primerApellido").val(datosCliente.PrimerApellido);
        $("#segundoApellido").val(datosCliente.SegundoApellido);
        $("#cedula").val(datosCliente.Cedula);
        $("#fechaNacimiento").val(datosCliente.FechaNacimiento);
        $("#telefono").val(datosCliente.Telefono);
        $("#sexo").val(datosCliente.Sexo);
        $("#correo").val(datosCliente.Correo);
        $("#provincia").val(datosCliente.Provincia).trigger('change');

        setTimeout(function () {
            $("#canton").val(datosCliente.Canton).trigger('change');
        }, 100);

        setTimeout(function () {
            $("#distrito").val(datosCliente.Distrito).trigger('change');
        }, 200);

        $("#direccionExacta").val(datosCliente.Direccion);
    }

    // Validar agregar cliente.
    function validarAgregarCliente() {

        let form = $("#formularioCliente")[0];

        let validarMandatorio = form.checkValidity();

        form.classList.add('was-validated');

        if (!validarMandatorio) {
            general.MostrarMensaje("E", "Validación Fallida", "Debe ingresar todos los campos obligatorios");
            return false;
        }

        return true;
    }

    // Agregar cliente.
    function agregarCliente() {

        let validacion = validarAgregarCliente();

        if (!validacion)
            return false;

        // Datos para enviar a guardar.
        let datos = {
            "PrimerNombre": $("#primerNombre").val(),
            "SegundoNombre": $("#segundoNombre").val(),
            "PrimerApellido": $("#primerApellido").val(),
            "SegundoApellido": $("#segundoApellido").val(),
            "Cedula": $("#cedula").val(),
            "FechaNacimiento": $("#fechaNacimiento").val(),
            "Telefono": $("#telefono").val(),
            "Sexo": $("#sexo").val(),
            "Correo": $("#correo").val(),
            "Provincia": $("#provincia").val(),
            "Canton": $("#canton").val(),
            "Distrito": $("#distrito").val(),
            "Direccion": $("#direccionExacta").val()
        };

        // Llamada Ajax para agregar el registro.
        $.ajax({
            url: base_url + "/Cliente/Agregar",
            type: "POST",
            data: JSON.stringify(datos),
            datatype: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuesta) {
                if (respuesta != null && respuesta != -1) {
                    general.MostrarMensaje("I", "Creación Éxitosa", "Se creo de manera éxitosa al nuevo cliente.");
                    tabla.draw();
                    $("#modalCliente").modal('hide'); // Ocultar el modal.
                } else {
                    general.MostrarMensaje("E", "Creación Fallida", "Ocurrió un error inesperado en la aplicación a la hora de crear al nuevo cliente.");
                }
            },
            error: function (request, status, error) {
                general.MostrarMensaje("E", "Creación Fallida", "Ocurrió un error inesperado en la aplicación.");
                // Bitacorizar el error.
            }
        });
    }

    // Editar cliente.
    function editarCliente(idCliente) {

        let validacion = validarAgregarCliente();

        if (!validacion)
            return false;

        // Datos para enviar a guardar.
        let datos = {
            "Id": idCliente,
            "PrimerNombre": $("#primerNombre").val(),
            "SegundoNombre": $("#segundoNombre").val(),
            "PrimerApellido": $("#primerApellido").val(),
            "SegundoApellido": $("#segundoApellido").val(),
            "Cedula": $("#cedula").val(),
            "FechaNacimiento": $("#fechaNacimiento").val(),
            "Telefono": $("#telefono").val(),
            "Sexo": $("#sexo").val(),
            "Correo": $("#correo").val(),
            "Provincia": $("#provincia").val(),
            "Canton": $("#canton").val(),
            "Distrito": $("#distrito").val(),
            "Direccion": $("#direccionExacta").val()
        };

        // Llamada Ajax para actualizar el registro.
        $.ajax({
            url: base_url + "/Cliente/Editar",
            type: "POST",
            data: JSON.stringify(datos),
            datatype: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuesta) {
                if (respuesta != null && respuesta == true) {
                    general.MostrarMensaje("I", "Actualización Éxitosa", "Se actualizó de manera éxitosa el cliente.");
                    tabla.draw();
                    $("#modalCliente").modal('hide'); // Ocultar el modal.
                } else {
                    general.MostrarMensaje("E", "Actualización Fallida", "Ocurrió un error inesperado en la aplicación a la hora de actualizar al cliente.");
                }
            },
            error: function (request, status, error) {
                general.MostrarMensaje("E", "Actualización Fallida", "Ocurrió un error inesperado en la aplicación.");
                // Bitacorizar el error.
            }
        });
    }

    // Eliminar cliente.
    function eliminarCliente(cliente) {

        general.MostrarMensaje(
            "A", // Tipo de error
            "Eliminar Cliente", // Título
            "¿Está seguro que desea eliminar el cliente?", // Mensaje
            { // Error
                titulo: "No"
            },
            { // En caso de aprobar borrado
                titulo: "Sí",
                callback: function () {
                    eliminarClienteAjax(cliente.Id);
                    return true;
                }
            }
        );
    }

    // Eliminar cliente por Ajax
    function eliminarClienteAjax(idCliente) {

        // Llamada Ajax para eliminar el registro.
        $.ajax({
            url: base_url + "/Cliente/Eliminar",
            type: "POST",
            data: JSON.stringify({ "Id": idCliente }),
            datatype: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuesta) {
                if (respuesta != null && respuesta == true) {
                    general.MostrarMensaje("I", "Eliminado exitosamente", "Se eliminó de manera éxitosa el cliente.");
                    tabla.draw();
                } else {
                    general.MostrarMensaje("E", "Eliminado Fallido", "Ocurrió un error inesperado en la aplicación a la hora de eliminar al cliente.");
                }
            },
            error: function (request, status, error) {
                general.MostrarMensaje("E", "Eliminado Fallido", "Ocurrió un error inesperado en la aplicación.");
                // Bitacorizar el error.
            }
        });
    }
}) ();