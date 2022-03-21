window.onload = function () {
    listarcambios();
    llenaridcargadevolucion();
    llenaridcargadevolucion2();
    llenarClientedevolucion();
    llenarusuariodevolucion();
    ListarReferencia();
    $("#BTNGUARDA").hide();
    LimpiarCambios();
    $("#idusuario").hide();
    $("#idcarga2").hide();
    //Fecha();
}
function listarcambios() {
    pintar({
        url: "Cambios/ListarCambios",
        id: "divTablacambios",
        cabeceras: ["Id", "Carga", "Cliente", "Fecha-Cambio"],
        propiedades: ["id", "idcarga", "cliente", "fechacadena"],
        //editar: true,
        eliminar: true,
        propiedadId: "id"
    })
}

function BuscarCliente() {
    var nombre = get("txtcliente");
    pintar({
        url: "Cambios/FiltrarCambios/?nombre=" + nombre,
        id: "divTablacambios",
        cabeceras: ["Id", "Carga", "Cliente", "Fecha-Cambio"],
        propiedades: ["id", "idcarga", "cliente", "fechacadena"],
        //editar: true,
        eliminar: true,
        propiedadId: "id"
    })
}

function llenaridcargadevolucion() {
    fetchGet("Cambios/ListarIdCarga", function (data) {
        //name input / atributo amostrar /atributo id
        llenarCombo(data, "idcarga", "idcarga", "idcarga")
    })
}


function ListarReferencia() {
    fetchGet("Cambios/ListarReferencia", function (data) {
        //name input / atributo amostrar /atributo id
        llenarCombo(data, "idref", "Ref", "idref")
    })
}


function llenaridcargadevolucion2() {
    fetchGet("Cambios/ListarIdCarga", function (data) {
        //name input / atributo amostrar /atributo id
        llenarCombo(data, "idcarga2", "idcarga", "idcarga")
    })
}

function llenarClientedevolucion() {
    fetchGet("Cambios/ListarCliente", function (data) {
        //name input / atributo amostrar /atributo id
        llenarCombo(data, "idcliente", "cliente", "idcliente")
    })
}

function llenarusuariodevolucion() {
    fetchGet("Cambios/ListarUsuario", function (data) {
        //name input / atributo amostrar /atributo id
        llenarCombo(data, "idusuario", "usuario", "idusuario")
    })
}

function LimpiarCambios() {
    LimpiarDatos("formulario", ["id"])
    $("#extr").val(0);
    $("#aar").val(0);
    $("#ar").val(0);
    $("#br").val(0);
    $("#extb").val(0);
    $("#aab").val(0);
    $("#ab").val(0);
    $("#bb").val(0);
    $("#cant").val(0);
   
} 



var cliente = document.getElementById("idcliente");
cliente.onchange = function () {
    var idcarga = get("idcarga");
    if (idcarga != 0) {
        BuscaCargaCambios();
       
    }
    else {
        $("#idcliente").val("");
        Error("Debe Seleccionar la Carga Primero");
    }
}


////Funcionpra Cargar los datos en los inputs en funcion del name usando fetchGet para carga asincrona
function BuscaCargaCambios() {
    var idcarga = get("idcarga");
    fetchGet("Cambios/RecuperarCargaCambios/?idcarga=" + idcarga, function (res) {      
        setN("idusuario", res.idusuario)   
        setN("fecha", res.fechacadena)
        setN("extr", res.extr)
        setN("aar", res.aar)
        setN("ar", res.ar)
        setN("br", res.br)
        setN("extb", res.extb)
        setN("aab", res.aab)
        setN("ab", res.ab)
        setN("bb", res.bb)
        var carga = get("idcarga");
        $("#idcarga2").val(carga);
        $("#idcarga2").hide();
    })

}


function Editar(id) {
    fetchGet("Cambios/RecuperarCambios/?id=" + id, function (res) {
        setN("id", res.id)
        setN("idcarga", res.idcarga)
        setN("idcliente", res.idcliente)
        setN("idref", res.idref)
        setN("cant", res.cant)
        setN("idusuario", res.idusuario)      
        setN("fecha", res.fechacadena)
       
    })
}


function guardarcambios() {
    var error = ValidarObligatorios("formulario")
    if (error != "") {
        Error(error);
        return;
    }
   
    var formulario = document.getElementById("formulario");
    var frm = new FormData(formulario);
    fetch("Cambios/guardarCambios", {
        method: "POST",
        body: frm
    }).then(res => res.text())
        .then(res => {
            if (res == "1") {
                modificaCargaCmbios();
            }
            else {
                Error("Error al Guardar el Cambio")
            }
           
        })

}


function modificaCargaCmbios() {
    var error = ValidarObligatorios("formulario2")
    if (error != "") {
        Error(error);
        return;
    }

    var formulario = document.getElementById("formulario2");
    var frm = new FormData(formulario);
    fetch("Cambios/modificaCargaCmbios", {
        method: "POST",
        body: frm
    }).then(res => res.text())
        .then(res => {
            if (res == "1") {
                $("#BTNGUARDA").hide();
                $("#BTNCALCULA").show();
                LimpiarCambios();
                listarcambios();
                Correcto("El Cambio se ha Realizado de Forma Correcta");
            }
            else {
                Error(" Error al procesar la Carga");
            }
        })

}

function Eliminar(id) {
    Editar(id);
    Confirmacion("Si Desea Eliminar el Cambio", "Confirme la  eliminaciòn", function (res) {
        fetchGetText("Cambios/EliminarCambio/?id=" + id, function (rpta) {
            if (rpta == "1") {
                Correcto("Se Elimino Correctamente el Cambio"); 
                Modificar();
            }
        })
    })
}



function Restarstockcambios() {
    var subtotal = 0;
    var extr = $("#extr").val();
    var aar = $("#aar").val();
    var ar = $("#ar").val();
    var br = $("#br").val();
    var extb = $("#extb").val();
    var aab = $("#aab").val();
    var ab = $("#ab").val();
    var bb = $("#bb").val();
    var cant = $("#cant").val();
    var ref = $("#idref").val();
    if (ref == 1) {
        if (parseInt(aar) >= parseInt(cant)) {
            subtotal = (aar - cant)
            console.info(subtotal);
            $("#aar").val(subtotal);
            $("#BTNGUARDA").show();
            $("#BTNCALCULA").hide();
        }
        else {
            Error("El Valor en Stock de la Referencia AAR:  " + aar + " Es Menor que la Cantidad a Cambiar:  " + cant + "  de la Referencia Seleccionada");
            $("#BTNGUARDA").hide();
            $("#BTNCALCULA").show();

        }
    }
    if (ref == 2) {
        if (parseInt(aab) >= parseInt(cant)) {
            subtotal = (aab - cant)
            console.info(subtotal);
            $("#aab").val(subtotal);
            $("#BTNGUARDA").show();
            $("#BTNCALCULA").hide();
        }
        else {
            Error("El Valor en Stock de la Referencia AAB:  " + aab + " Es Menor que la Cantidad a Cambiar:  " + cant + "  de la Referencia Seleccionada");
            $("#BTNGUARDA").hide();
            $("#BTNCALCULA").show();

        }
    }
    if (ref == 3) {
        if (parseInt(ar) >= parseInt(cant)) {
            subtotal = (ar - cant)
            console.info(subtotal);
            $("#ar").val(subtotal);
            $("#BTNGUARDA").show();
            $("#BTNCALCULA").hide();
        }
        else {
            Error("El Valor en Stock de la Referencia AR:  " + ar + " Es Menor que la Cantidad a Cambiar:  " + cant + "  de la Referencia Seleccionada");
            $("#BTNGUARDA").hide();
            $("#BTNCALCULA").show();
        }
    }
    if (ref == 4) {
        if (parseInt(ab) >= parseInt(cant)) {
            subtotal = (ab - cant)
            console.info(subtotal);
            $("#ab").val(subtotal);
            $("#BTNGUARDA").show();
            $("#BTNCALCULA").hide();
        }
        else {
            Error("El Valor en Stock de la Referencia Ab:  " + ab + " Es Menor que la Cantidad a Cambiar:  " + cant + "  de la Referencia Seleccionada");
            $("#BTNGUARDA").hide();
            $("#BTNCALCULA").show();
        }
    }
    if (ref == 5) {
        if (parseInt(extr) >= parseInt(cant)) {
            subtotal = (extr - cant)
            console.info(subtotal);
            $("#extr").val(subtotal);
            $("#BTNGUARDA").show();
            $("#BTNCALCULA").hide();
        }
        else {
            Error("El Valor en Stock de la Referencia EXTR:  " + extr + " Es Menor que la Cantidad a Cambiar:  " + cant + "  de la Referencia Seleccionada");
            $("#BTNGUARDA").hide();
            $("#BTNCALCULA").show();
        }
    }
    if (ref == 6) {
        if (parseInt(extb) >= parseInt(cant)) {
            subtotal = (extb - cant)
            console.info(subtotal);
            $("#extb").val(subtotal);
            $("#BTNGUARDA").show();
        }
        else {
            Error("El Valor en Stock de la Referencia EXTB:  " + extb + " Es Menor que la Cantidad a Cambiar:  " + cant + "  de la Referencia Seleccionada");
            $("#BTNGUARDA").hide();
            $("#BTNCALCULA").show();
        }
    }

    if (ref == 7) {
        if (parseInt(br) >= parseInt(cant)) {
            subtotal = (br - cant)
            console.info(subtotal);
            $("#br").val(subtotal);
            $("#BTNGUARDA").show();
            $("#BTNCALCULA").hide();
        }
        else {
            Error("El Valor en Stock de la Referencia BR:  " + br + " Es Menor que la Cantidad a Cambiar:  " + cant + "  de la Referencia Seleccionada");
            $("#BTNGUARDA").hide();
            $("#BTNCALCULA").show();
        }
    }
    if (ref == 8) {
        if (parseInt(bb) >= parseInt(cant)) {
            subtotal = (bb - cant)
            console.info(subtotal);
            $("#bb").val(subtotal);
            $("#BTNGUARDA").show();
            $("#BTNCALCULA").hide();
        }
        else {
            Error("El Valor en Stock de la Referencia BB:  " + bb + " Es Menor que la Cantidad a Cambiar:  " + cant + "  de la Referencia Seleccionada");
            $("#BTNGUARDA").hide();
            $("#BTNCALCULA").show();
        }
    }

}