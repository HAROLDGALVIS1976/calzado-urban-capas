using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAENTIDAD
{
    public class VentasCLS
    {
        public int idweb { get; set; }
        public int idref { get; set; }
        public string referencia { get; set; }
        public string descripcion { get; set; }
        public double valventa { get; set; }
        public double cant { get; set; }
        public double monto_total { get; set; }
        public string tipo { get; set; }
        public System.DateTime fechaventa { get; set; }
        public string usuario { get; set; }
        public string info1 { get; set; }
        public string info2 { get; set; }
        public string info3 { get; set; }
        //PROPIEDADES ADICINALES
        public string fechapagocadena { get; set; }
        public double valcosto { get; set; }
        public double valcostototal { get; set; }
        public double valventatotal { get; set; }
        public double stock2 { get; set; }
        public int idref2 { get; set; }
    }
}
