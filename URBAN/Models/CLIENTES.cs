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
    
    public partial class CLIENTES
    {
        public CLIENTES()
        {
            this.ABONOSVENTASCREDITO = new HashSet<ABONOSVENTASCREDITO>();
            this.VENTA_PROD = new HashSet<VENTA_PROD>();
            this.VENTASCREDITO = new HashSet<VENTASCREDITO>();
        }
    
        public int IDCLIENTE { get; set; }
        public string CLIENTE { get; set; }
        public string NUIP { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string CIUDAD { get; set; }
        public string EMAIL { get; set; }
        public int IDRUTA { get; set; }
        public Nullable<int> BHABILITADO { get; set; }
        public string TIPOUSUARIO { get; set; }
    
        public virtual ICollection<ABONOSVENTASCREDITO> ABONOSVENTASCREDITO { get; set; }
        public virtual RUTA RUTA { get; set; }
        public virtual ICollection<VENTA_PROD> VENTA_PROD { get; set; }
        public virtual ICollection<VENTASCREDITO> VENTASCREDITO { get; set; }
        public virtual TIPOUSUARIOREGISTRO TIPOUSUARIOREGISTRO { get; set; }
    }
}