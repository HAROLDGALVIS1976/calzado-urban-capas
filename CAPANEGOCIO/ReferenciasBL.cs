using CAPADATOS;
using CAPAENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPANEGOCIO
{
    public class ReferenciasBL
    {
        public List<ReferenciasCLS> ListarReferencias()
        {
            ReferenciasDAL oReferenciasDAL = new ReferenciasDAL();
            return oReferenciasDAL.ListarReferencias();
        }

        public List<ReferenciasCLS> FiltrarReferencias(string descripcion)
        {
            ReferenciasDAL oReferenciasDAL = new ReferenciasDAL();
            return oReferenciasDAL.FiltrarReferencias(descripcion);
        }
    }
}
