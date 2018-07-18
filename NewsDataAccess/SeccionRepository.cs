using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using NewsModel;

namespace NewsDataAccess
{
    public class SeccionRepository
    {
        //static string ConnectionString = "Data Source = .\\; Initial Catalog=Monitoreo; Integrated Security = True";
        static string ConnectionString = "Server=10.32.121.1;Database=Monitoreo;User Id=A01233540; Password=Jg3r@rdoB;";
        public static IEnumerable<Seccion> GetSecciones()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "Select *from Seccion";
            SqlDataReader reader = command.ExecuteReader();
            List<Seccion> secciones = new List<Seccion>();
            while (reader.Read())
            {
                Seccion seccion = new Seccion();
                seccion.SeccionID = (int)reader["seccionID"];
                seccion.NombreSeccion = reader["nombreSeccion"] as string;
                secciones.Add(seccion);
            }
            return secciones;
        }

        public static Seccion GetSeccion(int? id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "Select * from Seccion where seccionID = @id";
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            Seccion seccion = new Seccion();
            while (reader.Read())
            {
                seccion.SeccionID = (int)reader["seccionID"];
                seccion.NombreSeccion = reader["nombreSeccion"] as string;
            }
            return seccion;
        }

        public static bool InsertSeccion(Seccion seccion)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"insert into Seccion(nombreSeccion)
                                    values(@nombreSeccion)";
            command.Parameters.AddWithValue("@nombreSeccion", seccion.NombreSeccion);
            connection.Open();
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public static bool UpdateSeccion(Seccion seccion)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"update Seccion set NombreSeccion = @NombreSeccion where SeccionID = @seccionId";
            command.Parameters.AddWithValue("@nombreSeccion", seccion.NombreSeccion);
            command.Parameters.AddWithValue("@seccionId", seccion.SeccionID);
            connection.Open();
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public static bool DeleteSeccion(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"delete Seccion where SeccionID = @seccionId";
            command.Parameters.AddWithValue("@seccionId", id);
            connection.Open();
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
