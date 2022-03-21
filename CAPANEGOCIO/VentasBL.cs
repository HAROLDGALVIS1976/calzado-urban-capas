using CAPADATOS;
using CAPAENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPANEGOCIO
{
    public class VentasBL
    {
        public List<ReferenciasCLS> ListarReferencia()
        {
            ReferenciasDAL oReferenciasDAL = new ReferenciasDAL();
            return oReferenciasDAL.ListarReferencias();
        }
        public List<VentasCLS> FiltarVentasWeb(string usuario)
        {
            VentasDAL oVentaswebDAL = new VentasDAL();
            return oVentaswebDAL.FiltarVentasWeb(usuario);
        }
        public List<VentasCLS> ListarVentasWeb()
        {
            VentasDAL oVentaswebDAL = new VentasDAL();
            return oVentaswebDAL.ListarVentasWeb();
        }
        public ReferenciasCLS RecuperarRef(string descripcion)
        {
            VentasDAL oVentaswebDAL = new VentasDAL();
            return oVentaswebDAL.RecuperarRef(descripcion);
        }
        public int GuardarVenta(VentasCLS oVentaswebCLS)
        {
            VentasDAL oVentaswebDAL = new VentasDAL();
            return oVentaswebDAL.GuardarVenta(oVentaswebCLS);

        }
        public int ActualizaReferencia(VentasCLS oVentaswebCLS)
        {
            VentasDAL oVentaswebDAL = new VentasDAL();
            return oVentaswebDAL.ActualizaReferencia(oVentaswebCLS);
        }

        public int ModificaReferencia(VentasCLS oVentaswebCLS)
        {
            VentasDAL oVentaswebDAL = new VentasDAL();
            return oVentaswebDAL.ModificaReferencia(oVentaswebCLS);
        }
        public VentasCLS RecuperarVenta(int idweb)
        {
            VentasDAL oVentaswebDAL = new VentasDAL();
            return oVentaswebDAL.RecuperarVenta(idweb);
        }


        public int EliminarVenta(int idweb)
        {
            VentasDAL oVentaswebDAL = new VentasDAL();
            return oVentaswebDAL.EliminarVenta(idweb);
        }

        public List<ReferenciasCLS> ListarReferencias()
        {
            VentasDAL oVentasDAL = new VentasDAL();
            return oVentasDAL.ListarReferencias();
        }

        public List<ReferenciasCLS> FiltrarReferencias(string descripcion)
        {
            VentasDAL oVentasDAL = new VentasDAL();
            return oVentasDAL.FiltrarReferencias(descripcion);
        }

    }

}
