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
    
    public partial class CARROS
    {
        public CARROS()
        {
            this.ABONOSVENTASCREDITO = new HashSet<ABONOSVENTASCREDITO>();
            this.VENTASCREDITO = new HashSet<VENTASCREDITO>();
        }
    
        public int IDCARRO { get; set; }
        public string PLACA { get; set; }
        public Nullable<int> BHABILITADO { get; set; }
    
        public virtual ICollection<ABONOSVENTASCREDITO> ABONOSVENTASCREDITO { get; set; }
        public virtual ICollection<VENTASCREDITO> VENTASCREDITO { get; set; }
    }
}