using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyEmpresa.Entidad
{
    public class Ent_Usuario
    {
        public int codigo_usuario { get; set; }
        public string nombre { get; set; }
        public string contrasena { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public string descripcion { get; set; }
        public int codigo_area { get; set; }

    }
}
