using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAENTIDAD
{
    public class UusariosCLS
    {
        public int idusuario { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string tipousuario { get; set; }

        public int iid { get; set; }

        public int iidrol { get; set; }

        public int bhabilitado { get; set; }

        public string mensaje { get; set; }


        //Propiedades  Adicionales

        public string nombrePersona { get; set; }
        public string nombreRol { get; set; }
        public string nombreTipoEmpleado { get; set; }

        public string nombrePersonaEnviar { get; set; }
    }
}
