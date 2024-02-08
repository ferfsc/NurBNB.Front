$(document).ready(function () {
    var cadena = "";
    //Variables Usuario Primera vez    
    var cadenaUsuario = ""; var cadena_confirmaUsuario = "";
    var sw_nuevoUsuario = false, sw_confirmaUsuario = false ;

    //Variables Clave Acceso Primera Vez
    var cadena_anterior = ""; var cadena_nueva = ""; var cadena_confirma = "";
    var sw_anterior = false, sw_nueva = false, sw_confirma = false;
});

var v_shift = false;
function shift() {
    if (v_shift == false) {

        $("#n1").css('background', "url('letras/01-01.png')");
        $("#n2").css('background', "url('letras/01-02.png')");
        $("#n3").css('background', "url('letras/01-03.png')");
        $("#n4").css('background', "url('letras/01-04.png')");
        $("#n5").css('background', "url('letras/01-05.png')");
        $("#n6").css('background', "url('letras/01-06.png')");
        $("#n7").css('background', "url('letras/01-07.png')");
        $("#n8").css('background', "url('letras/01-08.png')");
        $("#n9").css('background', "url('letras/01-09.png')");

        $("#q").css('background', "url('letras/teclado-11.png')");
        $("#w").css('background', "url('letras/teclado-12.png')");
        $("#e").css('background', "url('letras/teclado-13.png')");
        $("#r").css('background', "url('letras/teclado-14.png')");
        $("#t").css('background', "url('letras/teclado-15.png')");
        $("#y").css('background', "url('letras/teclado-16.png')");
        $("#u").css('background', "url('letras/teclado-17.png')");
        $("#i").css('background', "url('letras/teclado-18.png')");
        $("#o").css('background', "url('letras/teclado-19.png')");
        $("#p").css('background', "url('letras/teclado-20.png')");
        $("#a").css('background', "url('letras/teclado-21.png')");
        $("#s").css('background', "url('letras/teclado-22.png')");
        $("#d").css('background', "url('letras/teclado-23.png')");
        $("#f").css('background', "url('letras/teclado-24.png')");
        $("#g").css('background', "url('letras/teclado-25.png')");
        $("#h").css('background', "url('letras/teclado-26.png')");
        $("#j").css('background', "url('letras/teclado-27.png')");
        $("#k").css('background', "url('letras/teclado-28.png')");
        $("#l").css('background', "url('letras/teclado-29.png')");
        $("#ñ").css('background', "url('letras/teclado-30.png')");
        $("#z").css('background', "url('letras/teclado-31.png')");
        $("#x").css('background', "url('letras/teclado-32.png')");
        $("#c").css('background', "url('letras/teclado-33.png')");
        $("#v").css('background', "url('letras/teclado-34.png')");
        $("#b").css('background', "url('letras/teclado-35.png')");
        $("#n").css('background', "url('letras/teclado-36.png')");
        $("#m").css('background', "url('letras/teclado-37.png')");
        $("#shift").css('background', "url('letras/02-28.png')");

        $("#coma").css('background', "url('letras/02--38.png')");
        $("#punto").css('background', "url('letras/02--39.png')");
        $("#guion").css('background', "url('letras/02--41.png')");

        v_shift = true;
    } else {

        $("#n1").css('background', "url('letras/teclado-01.png')");
        $("#n2").css('background', "url('letras/teclado-02.png')");
        $("#n3").css('background', "url('letras/teclado-03.png')");
        $("#n4").css('background', "url('letras/teclado-04.png')");
        $("#n5").css('background', "url('letras/teclado-05.png')");
        $("#n6").css('background', "url('letras/teclado-06.png')");
        $("#n7").css('background', "url('letras/teclado-07.png')");
        $("#n8").css('background', "url('letras/teclado-08.png')");
        $("#n9").css('background', "url('letras/teclado-09.png')");


        $("#q").css('background', "url('letras/02-01.png')");
        $("#w").css('background', "url('letras/02-02.png')");
        $("#e").css('background', "url('letras/02-03.png')");
        $("#r").css('background', "url('letras/02-04.png')");
        $("#t").css('background', "url('letras/02-05.png')");
        $("#y").css('background', "url('letras/02-06.png')");
        $("#u").css('background', "url('letras/02-07.png')");
        $("#i").css('background', "url('letras/02-08.png')");
        $("#o").css('background', "url('letras/02-09.png')");
        $("#p").css('background', "url('letras/02-10.png')");
        $("#a").css('background', "url('letras/02-11.png')");
        $("#s").css('background', "url('letras/02-12.png')");
        $("#d").css('background', "url('letras/02-13.png')");
        $("#f").css('background', "url('letras/02-14.png')");
        $("#g").css('background', "url('letras/02-15.png')");
        $("#h").css('background', "url('letras/02-16.png')");
        $("#j").css('background', "url('letras/02-17.png')");
        $("#k").css('background', "url('letras/02-18.png')");
        $("#l").css('background', "url('letras/02-19.png')");
        $("#ñ").css('background', "url('letras/02-20.png')");
        $("#z").css('background', "url('letras/02-21.png')");
        $("#x").css('background', "url('letras/02-22.png')");
        $("#c").css('background', "url('letras/02-23.png')");
        $("#v").css('background', "url('letras/02-24.png')");
        $("#b").css('background', "url('letras/02-25.png')");
        $("#n").css('background', "url('letras/02-26.png')");
        $("#m").css('background', "url('letras/02-27.png')");

        $("#coma").css('background', "url('letras/teclado-fassil original-38.png')");
        $("#punto").css('background', "url('letras/teclado-fassil original-39.png')");
        $("#guion").css('background', "url('letras/teclado-fassil original-41.png')");

        $("#shift").css('background', "url('letras/teclado-38.png')");
        v_shift = false;
    }
}

var cadena = "";

//Variables Usuario Primera Vez
var cadenaUsuario = ""; var cadena_confirmaUsuario = ""; 
var sw_nuevoUsuario = false, sw_confirmaUsuario = false;

//Variables Clave Acceso Primera Vez
var cadena_anterior = ""; var cadena_nueva = ""; var cadena_confirma = "";
var sw_anterior=false, sw_nueva=false, sw_confirma=false;

function tecla_oprimida(tecla) {
    if (v_shift == true) {
        if (!isNumber(tecla)) {
            tecla = tecla.toUpperCase();
        }else{
            tecla = valor_equivalente(tecla);
        }
    } else {
        if (!isNumber(tecla)) {
            tecla = tecla.toLowerCase();
        } else {
            if (isCaracter(tecla)) {
                tecla = asignarsimbolo(tecla);
            } else {
                tecla = tecla.charAt(1);
            }
        }
    }

    if (sw_anterior != false || sw_nueva != false || sw_confirma != false || sw_nuevoUsuario != false || sw_confirmaUsuario != false) {
        if (sw_anterior) {
            cadena_anterior = cadena_anterior + tecla;
            $("#txtClaveAnterior").val(cadena_anterior);
            $("#ContentPlaceHolder_txtClaveAnterior").val(cadena_anterior);
        } else if (sw_nueva) {
            cadena_nueva = cadena_nueva + tecla;
            $("#txtClaveNueva").val(cadena_nueva);
            $("#ContentPlaceHolder_txtClaveNueva").val(cadena_nueva);
        } else if (sw_confirma) {
            cadena_confirma = cadena_confirma + tecla;
            $("#txtClaveConfirma").val(cadena_confirma);
            $("#ContentPlaceHolder_txtClaveConfirma").val(cadena_confirma);
        } else if (sw_nuevoUsuario) {
            cadenaUsuario = cadenaUsuario + tecla;
            $("#txtNuevoUsuario").val(cadenaUsuario);
            $("#ContentPlaceHolder_txtNuevoUsuario").val(cadenaUsuario);
        } else if (sw_confirmaUsuario) {
            cadena_confirmaUsuario = cadena_confirmaUsuario + tecla;
            $("#txtConfirmaUsuario").val(cadena_confirmaUsuario);
            $("#ContentPlaceHolder_txtConfirmaUsuario").val(cadena_confirmaUsuario);
        }
    } else {
        cadena = cadena + tecla;
        $(".tokenOtp").val(cadena);
    }

}

var cadena_nro = "";
//Variables Clave Transaccional Primera Vez
var nro_anterior = ""; var nro_nueva = ""; var nro_confirma = "";
var sw_anterior_trans = false, sw_nueva_trans = false, sw_confirma_trans = false;

function tecla_oprimida_nro(tecla) {
    tecla = tecla.charAt(1);
    if (sw_anterior_trans != false || sw_nueva_trans != false || sw_confirma_trans != false) {
        if (sw_anterior_trans) {
            //if (nro_anterior.length < 4) {
                nro_anterior = nro_anterior + tecla;
            //}
            $("#txtTransAnterior").val(nro_anterior);
            $("#ContentPlaceHolder_txtTransAnterior").val(nro_anterior);
        } else if (sw_nueva_trans) {
            //if (nro_nueva.length < 4) {
                nro_nueva = nro_nueva + tecla;
            //}
            $("#txtTransNueva").val(nro_nueva);
            $("#ContentPlaceHolder_txtTransNueva").val(nro_nueva);
        } else if (sw_confirma_trans) {
            //if (nro_confirma.length < 4) {
                nro_confirma = nro_confirma + tecla;
            //}
            $("#txtTransConfirmar").val(nro_confirma);
            $("#ContentPlaceHolder_txtTransConfirmar").val(nro_confirma);
        }
    } else {
            cadena_nro = cadena_nro + tecla;
        $(".tokenOtp").val(cadena_nro);
    }
}


function espacio() {
    if (sw_anterior != false || sw_nueva != false || sw_confirma != false || sw_nuevoUsuario != false || sw_confirmaUsuario != false) {
        if (sw_anterior) {
            cadena_anterior = cadena_anterior + " ";
            $("#txtClaveAnterior").val(cadena_anterior);
            $("#ContentPlaceHolder_txtClaveAnterior").val(cadena_anterior);
        } else if (sw_nueva) {
            cadena_nueva = cadena_nueva + " ";
            $("#txtClaveNueva").val(cadena_nueva);
            $("#ContentPlaceHolder_txtClaveNueva").val(cadena_nueva);
        } else if (sw_confirma) {
            cadena_confirma = cadena_confirma + " ";
            $("#txtClaveConfirma").val(cadena_confirma);
            $("#ContentPlaceHolder_txtClaveConfirma").val(cadena_confirma);
        } else if (sw_nuevoUsuario) {
            cadenaUsuario = cadenaUsuario + " ";
            $("#txtNuevoUsuario").val(cadenaUsuario);
            $("#ContentPlaceHolder_txtNuevoUsuario").val(cadenaUsuario);
        } else if (sw_confirmaUsuario) {
            cadena_confirmaUsuario = cadena_confirmaUsuario + " ";
            $("#txtConfirmaUsuario").val(cadena_confirmaUsuario);
            $("#ContentPlaceHolder_txtConfirmaUsuario").val(cadena_confirmaUsuario);
        }
    } else {
        cadena = cadena + " ";
        $(".tokenOtp").val(cadena_nro);
    }
}

function borrar() {
    if (sw_anterior != false || sw_nueva != false || sw_confirma != false || sw_nuevoUsuario != false || sw_confirmaUsuario != false) {
        if (sw_anterior) {
            cadena_anterior = cadena_anterior.slice(0, -1);
            $("#txtClaveAnterior").val(cadena_anterior);
            $("#ContentPlaceHolder_txtClaveAnterior").val(cadena_anterior);
        } else if (sw_nueva) {
            cadena_nueva = cadena_nueva.slice(0, -1);
            $("#txtClaveNueva").val(cadena_nueva);
            $("#ContentPlaceHolder_txtClaveNueva").val(cadena_nueva);
        } else if (sw_confirma) {
            cadena_confirma = cadena_confirma.slice(0, -1);
            $("#txtClaveConfirma").val(cadena_confirma);
            $("#ContentPlaceHolder_txtClaveConfirma").val(cadena_confirma);
        } if (sw_nuevoUsuario) {
            cadenaUsuario = cadenaUsuario.slice(0, -1);
            $("#txtNuevoUsuario").val(cadenaUsuario);
            $("#ContentPlaceHolder_txtNuevoUsuario").val(cadenaUsuario);
        } if (sw_confirmaUsuario) {
            cadena_confirmaUsuario = cadena_confirmaUsuario.slice(0, -1);
            $("#txtConfirmaUsuario").val(cadena_confirmaUsuario);
            $("#ContentPlaceHolder_txtConfirmaUsuario").val(cadena_confirmaUsuario);
        }
    } else { 
        cadena = cadena.slice(0, -1);
        $(".tokenOtp").val(cadena_nro);
    }
}

function borrar_nro() {
    if (sw_anterior_trans != false || sw_nueva_trans != false || sw_confirma_trans != false) {
        if (sw_anterior_trans) {
            nro_anterior = "";
            $("#txtTransAnterior").val(nro_anterior);
            $("#ContentPlaceHolder_txtTransAnterior").val(nro_anterior);
        } else if (sw_nueva_trans) {
            nro_nueva = "";
            $("#txtTransNueva").val(nro_nueva);
            $("#ContentPlaceHolder_txtTransNueva").val(nro_nueva);
        } else if (sw_confirma_trans) {
            nro_confirma = "";
            $("#txtTransConfirmar").val(nro_confirma);
            $("#ContentPlaceHolder_txtTransConfirmar").val(nro_confirma);
        }
    } else {
        cadena_nro = "";
        $(".tokenOtp").val(cadena_nro);
    }
    cargar_random();
}

function isNumber(caracter) {
    if (caracter == 'n0' || caracter == 'n1' || caracter == 'n2' || caracter == 'n3' || caracter == 'n4' || caracter == 'n5' || caracter == 'n6' || caracter == 'n7' || caracter == 'n8' ||
        caracter == 'n9' || caracter == 'coma' || caracter == 'punto' || caracter == 'guion')
        return true;
}

function isCaracter(caracter) {
    if (caracter == 'coma' || caracter == 'punto' || caracter == 'guion')
        return true;
}

function asignarsimbolo(tecla) {
    switch (tecla) {
        case "coma": return ",";
        case "punto": return ".";
        case "guion": return "-";
    }
}

function valor_equivalente(numero) {
    switch (numero) {
        case "n1": return "!";
        case "n2": return "+";
        case "n3": return "#";
        case "n4": return "*";
        case "n5": return "[";
        case "n6": return "]";
        case "n7": return "(";
        case "n8": return ")";
        case "n9": return "=";
        case "n0": return "0";
        case "coma": return ";";
        case "punto": return ":";
        case "guion": return "_";
    }
}

function cargar_random() {
    cadena_nro = ""; nro_anterior = ""; nro_confirma = ""; nro_nueva = "";
    cadena = "";
    var lista = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
    lista = lista.sort(function () {
        return Math.random() - 0.5
    });

    $("#idTecladoNumerico").empty();
    for (i = 0; i <= 9; i++) {
        nro = lista[i];
        cadena = cadena + "<li id=\"t" + nro + "\" class=\"nro\" onclick=\"tecla_oprimida_nro(this.id)\"></li>";
    }
    cadena= cadena + "<li id=\"borrar_nro\" onclick=\"borrar_nro()\"></li>"
    $("#idTecladoNumerico").append(cadena);
}

function limpiar(){
    cadena_nro = ""; nro_anterior = ""; nro_confirma = ""; nro_nueva = "";
    cadena = "";
}