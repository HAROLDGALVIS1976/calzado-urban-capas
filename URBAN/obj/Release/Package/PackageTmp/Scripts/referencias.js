window.onload = function () {
    listareferencias();
}
function listareferencias() {
    pintar({
        url: "Referencias/ListarReferencias",
        id: "divTablaRef",
        cabeceras: ["Id", "Ref", "Descripcion","Cant", "ValVenta"],
        propiedades: ["idref", "referencia", "descripcion", "cant", "valventa"],
        propiedadId: "idref"
    })
}

function Buscareferencia() {
    var descripcion = get("txtdescripcion");
    pintar({
        url: "Referencias/FiltrarReferencias/?descripcion=" + descripcion,
        id: "divTablaRef",
        cabeceras: ["Id", "Ref", "Descripcion", "Cant", "ValVenta"],
        propiedades: ["idref", "referencia", "descripcion", "cant", "valventa"],
        propiedadId: "idref"
    })
}

