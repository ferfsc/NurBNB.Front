//bloqueo de pantalla
function bloqueo() {
    $.blockUI({
        message: $('#Block_div'),
        css:
            {
                padding: 0,
                margin: 0,
                textAlign: 'center',
                fontSize: 12,
                cursor: 'auto',
                border: 'none',
                background: 'none'
            },
        baseZ: 10000,
    });
}

//desbloqueo de pantalla
function closeLoading() {
    $.unblockUI();
}

//evita seleccionar mas de un radiobutton
function UnicoRadioButton(nameregex, current) {
    var pattern = new RegExp(nameregex);
    for (var i = 0; i < document.forms[0].elements.length; i++) {
        var elm = document.forms[0].elements[i];
        if (elm.type === 'radio' && pattern.test(elm.name)) {
            elm.checked = false;
        }
    }
    current.checked = true;
}

function abrirPopUp(url) {
    const izq = (screen.width - 800) / 2;
    const arr = (screen.height - 900) / 2;
    const look = 'location=no,status=yes,toolbar=yes,scrollbars=yes,resizable=no,width=' + 800 + ',height=' + 550 + ',top=' + arr + ',left=' + izq + ',';
    let popwin = window.open(url, "", look);
    popwin.location.href = url;
    popwin.focus();
    return false;
}

function abrirPopUpModal(url) {
    const izq = (screen.width - 800) / 2;
    const arr = (screen.height - 900) / 2;
    const look = 'location=no,status=yes,toolbar=yes,scrollbars=yes,resizable=no,width=' + 880 + ',height=' + 550 + ',top=' + arr + ',left=' + izq + ',';
    let popwin = window.open(url, "", look);
    popwin.location.href = url;
    popwin.focus();
    return false;
}


//admite solo numero y punto decimal
function numerosYpunto(myfield, e, dec) {
    let key;
    let keychar;
    if (window.event)
        key = window.event.keyCode;
    else if (e)
        key = e.which;
    else
        return true;

    keychar = String.fromCharCode(key);
    // control keys
    if ((key == null) || (key === 0) || (key === 8) || (key === 9) || (key === 13) || (key === 27) || (key === 46))
        return true;
    // numbers
    else if ((("0123456789").indexOf(keychar) > -1))
        return true;
    // decimal point jump
    else if (dec && (keychar === ".")) {
        myfield.form.elements[dec].focus();
        return false;
    } else
        return false;
}

//admite solo numeros
function numeros(myfield, e, dec) {
    let key;
    let keychar;
    if (window.event)
        key = window.event.keyCode;
    else if (e)
        key = e.which;
    else
        return true;

    keychar = String.fromCharCode(key);
    // control keys
    if ((key == null) || (key === 0) || (key === 8) || (key === 9) || (key === 13) || (key === 27))
        return true;
    // numbers
    else if ((("0123456789").indexOf(keychar) > -1))
        return true;
    // decimal point jump
    else if (dec && (keychar === ".")) {
        myfield.form.elements[dec].focus();
        return false;
    } else
        return false;
}

function esAlfanumerico(e) {
    var charCode

    if (navigator.appName == "Netscape") {
        charCode = e.which
        console.log("e.which: " + charCode);
    }
    else {
        charCode = e.keyCode
        console.log("e.kode: " + charCode);
    }
    if ((charCode >= 48 && charCode <= 57) || (charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122)) {
        console.log("return 1: " + true);
        return true
    }
    else {
        var Caracteres = "#&():; _-./@";
        console.log("caracteres: " + Caracteres);
    }

    if (Caracteres.indexOf(String.fromCharCode(charCode), 0) != -1) {
        console.log("return 2 : " + true);
        return true;
    }

    return false
}


// funcion que se ejecutara al inicio de cada pagina
function loadpage() {
    //bloquear pantalla
    $('#Block_div').click(function () {
        $.unblockUI();
    });

    $(document).ready(function ($) {
        //restriccion de input
        $("input.claseMonto").mask("99999999999999.99");
        //tablas
        $("table.tarjetas").DataTable({
            scrollY: '45vh',
            scrollCollapse: true,
            paging: false,
            info: false,
            searching: false,
            stateSave: true,
            fixedHeader: true,
            retrieve: true,
        });
        $("table.cuentasOrigen").DataTable({
            scrollY: '45vh',
            scrollCollapse: true,
            paging: false,
            info: false,
            searching: false,
            stateSave: true,
            retrieve: true,
        });

        $("table.cuentasDestino").DataTable({
            scrollY: '45vh',
            scrollCollapse: true,
            paging: false,
            stateSave: true,
            retrieve: true,
            //ordering: false,
            info: false,
            //searching: false,
            // order: [[2, "asc"], [3, "asc"]],
            language: {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            }
        });

       $("table.movimientos").DataTable({
            retrieve: true,
            stateSave: true,
            scrollY: '65vh',
            scrollCollapse: true,
            //paging: false,
            ordering: false,
            info: false,
            //searching: false,
            //order: [[2, "asc"],[3, "asc"]],
            language: {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            }
        });
        $("table.movimientosWeb").DataTable({
            stateSave: true,
            //scrollY: '65vh',
            scrollCollapse: true,
            paging: true,
            bAutoWidth: false,
            ordering: false,
            info: true,
            searching: true,
            scrollX: true,
            retrieve: true,
            //order: [[2, "asc"],[3, "asc"]],
            language: {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_",
                "sZeroRecords": "No se encontraron movimientos",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando del _START_ al _END_ de _TOTAL_",
                "sInfoEmpty": "Mostrando del 0 al 0 de 0",
                "sInfoFiltered": "(filtrado de _MAX_ )",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            }
        });

    });
}

function abrirPopUp(url) {
    var izq = (screen.width - 800) / 2;
    var arr = (screen.height - 900) / 2;
    var look = 'location=no,status=yes,toolbar=yes,scrollbars=yes,resizable=no,width=' + 800 + ',height=' + 550 + ',top=' + arr + ',left=' + izq + ','
    popwin = window.open(url, "", look);
    popwin.location.href = url;
    popwin.focus();
    return false;
}

function validateFloatKeyPress(el, evt, ints, decimals) {

    ints = 6;
    decimals = 2;
    // El punto lo cambiamos por la coma
    //if (evt.keyCode == 46) {
    //    evt.keyCode = 44;
    //}

    var Importe = $("#ContentPlaceHolder_txtImporte");
    Importe.text = el.value;


    if (el.value == "0.00")
        el.value = "";

    if (evt.keyCode == 13) {
        evt.keyCode = 9;
        return false;
    }

    if (evt.keyCode == 44) {
        evt.keyCode = 46;
    }


    // Valores numéricos
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57)) {
        return false;
    }

    // Sólo un punto
    if (charCode == 46) {
        if (el.value.indexOf(".") !== -1) {
            return false;
        }

        return true;
    }

    // Determinamos si hay decimales o no
    if (el.value.indexOf(".") == -1) {
        // Si no hay decimales, directamente comprobamos que el número que hay ya supero el número de enteros permitidos
        if (el.value.length >= ints) {
            return false;
        }
    } else {

        //Limpiamos el control
        // Damos el foco al elemento
        el.focus();
        var lenTotal = el.value.length;
        var indice = el.value.indexOf('.');
        var decimales = el.value;
        var cantDecimal = decimales.substr(indice + 1, lenTotal);

        if (cantDecimal.length >= 2)
            return false;
    }

    return true;
}
