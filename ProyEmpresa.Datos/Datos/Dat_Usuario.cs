using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ProyEmpresa.Entidad;
using System.Data;
using System.Data.SqlClient;

namespace ProyEmpresa
{
    public class Dat_Usuario
    {
        private string Cadena;

        public List<Ent_Usuario> ListaUsuario()
        {
            Cadena =   ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            List<Ent_Usuario> Lst_Usuario = new List<Ent_Usuario>();

            using (SqlConnection cn = new SqlConnection(Cadena))
            {
                cn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = cn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SPS_USUARIO";

                SqlDataReader dr;
                dr = command.ExecuteReader();

                if (dr.Read())
                {
                    while (dr.Read())
                    {
                        Ent_Usuario ent_user = new Ent_Usuario
                        {
                            codigo_usuario = int.Parse(dr["codigo_usuario"].ToString()),
                            nombre = dr["nombre"].ToString(),
                            fecha_ingreso = DateTime.Parse(dr["fecha_ingreso"].ToString()),
                            descripcion = dr["descripcion"].ToString()
                        };

                        Lst_Usuario.Add(ent_user);
                    };
                }

                return Lst_Usuario;
            }

        }

        public string Registra(Ent_Usuario ent_Usuario)
        {
            Cadena = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            string resultado = string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = cn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPI_USUARIO";

                    command.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = ent_Usuario.nombre;
                    command.Parameters.Add("@contrasena", SqlDbType.VarChar, 30).Value = ent_Usuario.contrasena;
                    command.Parameters.Add("@fecha_ingreso", SqlDbType.DateTime).Value = ent_Usuario.fecha_ingreso;
                    command.Parameters.Add("@codigo_area", SqlDbType.Int).Value = ent_Usuario.codigo_area;

                    command.ExecuteNonQuery();

                    resultado = "01";
                }
            }
            catch (Exception ex)
            {
                resultado = "00";
            }

            return resultado;
        }
    }




}
