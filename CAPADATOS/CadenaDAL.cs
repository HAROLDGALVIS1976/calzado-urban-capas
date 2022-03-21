using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPADATOS
{
    public class CadenaDAL
    {
        public string cadena { get; set; }
        public CadenaDAL()
        {
            try
            {
                cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            }
            catch (Exception ex)
            {
                cadena = null;

            }
        }
    }
}
