//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace URBAN.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class COMPRASCREDITO
    {
        public int ID { get; set; }
        public string FACTURA { get; set; }
        public string PROVEEDOR { get; set; }
        public double MONTODEUDA { get; set; }
        public string TIPO { get; set; }
        public System.DateTime FECHAPAGO { get; set; }
        public Nullable<int> BHABILITADO { get; set; }
    }
}