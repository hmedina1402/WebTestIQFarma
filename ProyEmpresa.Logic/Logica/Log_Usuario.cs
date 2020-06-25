using ProyEmpresa.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyEmpresa.Logic.Logica
{

    public class Log_Usuario
    {
        public List<Ent_Usuario> ListaUsuario()
        {
            Dat_Usuario dat_Usuario = new Dat_Usuario();
            return dat_Usuario.ListaUsuario();
        }

        public string Registra(Ent_Usuario ent_Usuario)
        {
            Dat_Usuario dat_Usuario = new Dat_Usuario();
            return dat_Usuario.Registra(ent_Usuario);
        }
    }
}
