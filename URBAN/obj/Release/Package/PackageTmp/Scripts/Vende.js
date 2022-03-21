window.onload = function () {
    llenarComboRef();
    Fecha();
    FiltrarVentasWeb();
    $("#BTNGUARDA").hide();
    $("#BTNNOTIFICA").hide();
    
}


function Fecha() {
    var now = new Date();   
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = now.getFullYear() + "-" + (month) + "-" + (day);

    $("#fechaventa").val(today);
}


    

function llenarComboRef() {
    fetchGet("Ventas/ListarReferencia", function (data) {
        //name input / atributo amostrar /atributo id
        llenarCombo(data, "idref", "referencia", "idref")
    })
}

function ListarVentasWeb() {
   
    pintar({
        url: "Ventas/ListarVentasWeb",
        id: "divTablaVentas",
        cabeceras: ["Id", "Ref", "Cant", "Cliente", "Fecha"],
        propiedades: ["idweb", "referencia", "cant", "info1", "fechapagocadena"],
       /* editar: true,*/
       /* eliminar: true,*/
        propiedadId: "idweb"
    })
}

function listareferencias() {
    pintar({
        url: "Ventas/ListarReferencias",
        id: "divTablaRef",
        cabeceras: ["Id", "Ref", "Descripcion", "Cant"],
        propiedades: ["idref", "referencia", "descripcion", "cant"],
        propiedadId: "idref"
    })
}

function Buscareferencia() {
    var descripcion = get("txtdescripcion");
    pintar({
        url: "Ventas/FiltrarReferencias/?descripcion=" + descripcion,
        id: "divTablaRef",
        cabeceras: ["Id", "Ref", "Descripcion", "Cant"],
        propiedades: ["idref", "referencia", "descripcion", "cant"],
        editar: true,
        propiedadId: "idref"
    })
}

function FiltrarVentasWeb() {
    var usuario = get("usuario")
    pintar({
        url: "Ventas/FiltarVentasWeb/?usuario=" + usuario,
        id: "divTablaVentas",
        cabeceras: ["Id", "Ref", "Cant", "Cliente", "Fecha"],
        propiedades: ["idweb", "referencia", "cant", "info1", "fechapagocadena"],
        /* editar: true,*/
       /* eliminar: true,*/
        propiedadId: "idweb"
    })
}

//funcion para filtrar la tabla en funcion de un input
function Editar(descripcion) {
    var descripcion = get("txtdescripcion");
    fetchGet("Ventas/RecuperarRef/?descripcion=" + descripcion, function (res) {
        setN("idref", res.idref);
        setN("stock", res.cant);
        setN("valventa", res.valventa);
        setN("descripcion", res.descripcion);     
        setN("valcosto", res.valcosto);
        setN("idref2", res.idref);       
        $("#BTNCALCULA").show();
        $("#BTNGUARDA").hide();
        Fecha();
        
    })
}


//function Editar2(idweb) {
//    var idweb = get("idweb");
//    fetchGet("Ventas/RecuperarVenta/?idweb=" + idweb, function (res) {
//        setN("idweb", res.idweb);
//        setN("idref", res.idref);
//        setN("descripcion", res.descripcion);
//        setN("valventa", res.valventa);
//        setN("cant", res.cant);
//        setN("monto_total", res.monto_total);
//        setN("tipo", res.tipo);
//        setN("fechaventa", res.fechapagocadena);
//        setN("usuario", res.usuario);
//        setN("info1", res.info1);
       
//    })
//}

function restar() {
    
    var cant = $("#cant").val();
    var stock = $("#stock").val();
    var stock2 = 0;
    var valuni = $("#valventa").val();
    var valcosto = $("#valcosto").val();
    
    var montoventa = 0;
    var totcost = 0;
    var totvent = 0;

    if (cant != 0) {
        if (parseFloat(stock) >= parseFloat(cant)) {
           
            montoventa = (cant * valuni);
            console.info(montoventa);
            $("#monto_total").val(montoventa);

            stock2 = (stock - cant);
            console.info(stock2);
            parseFloat(stock2)
            $("#stock2").val(stock2);
            
            totcost = (stock2 * valcosto);
            console.info(totcost);
            parseFloat(totcost)
            $("#valtotcosto").val(totcost);
           
            totvent = (stock2 * valuni);
            console.info(totvent);
            parseFloat(totvent)
            $("#valtotventa").val(totvent);

            $("#BTNCALCULA").hide();
            $("#BTNGUARDA").show();
            
        }
        else {
            Error("El Valor en Stock de la Referencia Es Menor que la Cantidad a Vender");
            $("#BTNCALCULA").show();
            $("#BTNGUARDA").hide();
            $("#BTNNOTIFICA").hide();
            
        }

    }
    else {
        Error("Ingrese la Cantidad de forma correcta");
    }
}

function limpiar() {
    LimpiarDatos("frmventas", ["fechaventa", "tipo", "cliente", "direccion", "telefono", "usuario", "info1", "info2", "info3", "valtotcosto", "valtotventa"]);
    $("#idweb").val(0);
}
function limpiar2() {
    LimpiarDatos("frmventas",);
    
}






