using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitoreoModels;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace NewsDataAccess
{
    public class UsuarioRepository
    {
        //static string ConnectionString = "Data Source = .\\; Initial Catalog=Monitoreo; Integrated Security = True";
        static string ConnectionString = "Server=10.32.121.1;Database=Monitoreo;User Id=A01233540; Password=Jg3r@rdoB;";
        public static bool VerifyUser(Usuario usuario)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "Select count(*) from Usuario where NombreUsuario = @nombreUsuario and Password = @pass";
            command.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
            command.Parameters.AddWithValue("@pass", usuario.Password);
            int c = (int)command.ExecuteScalar();

            if (c == 1)
                return true;
            else
                return false;
        }

        public static Usuario GetUsuario(Usuario usuario)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "Select * from Usuario where NombreUsuario = @nombreUsuario and Password = @pass";
            command.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
            command.Parameters.AddWithValue("@pass", usuario.Password);
            SqlDataReader reader = command.ExecuteReader();
            Usuario user = new Usuario();
            while (reader.Read())
            {
                user.NombreUsuario = reader["NombreUsuario"] as string;
                user.Password = reader["Password"] as string;
                user.Rol = reader["Rol"] as string;
            }
            return user;

        }

        //public static bool InsertUsuario(Usuario usuario)
        //{
        //    SqlConnection connection = new SqlConnection(ConnectionString);
        //    SqlCommand command = connection.CreateCommand();
        //    connection.Open();
        //    command.CommandText = "Select * from Usuario where NombreUsuario = @nombreUsuario";
        //    command.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
        //    SqlDataReader reader = command.ExecuteReader();
        //    Usuario user = new Usuario();
        //    while (reader.Read())
        //    {
        //        user.NombreUsuario = reader["NombreUsuario"] as string;
        //        user.Password = reader["Password"] as string;
        //    }
        //    return user;
        //}

    }
}

