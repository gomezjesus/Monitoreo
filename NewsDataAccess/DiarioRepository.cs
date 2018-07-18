using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MonitoreoModels;
namespace NewsDataAccess
{
   public class DiarioRepository
    {
        //static string ConnectionString = "Data Source = .\\; Initial Catalog=Monitoreo; Integrated Security = True";
        static string ConnectionString = "Server=10.32.121.1;Database=Monitoreo;User Id=A01233540; Password=Jg3r@rdoB;";
        public static IEnumerable<DiarioImpreso> GetDiarios()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "Select *from DiarioImpreso";
            SqlDataReader reader = command.ExecuteReader();
            List<DiarioImpreso> diarios = new List<DiarioImpreso>();
            while (reader.Read())
            {
                DiarioImpreso diario = new DiarioImpreso();
                diario.DiarioID = (int)reader["DiarioID"];
                diario.Nombre = reader["Nombre"] as string;
                diarios.Add(diario);
            }
            return diarios;
        }

        public static DiarioImpreso GetDiario(int? id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "Select * from DiarioImpreso where DiarioId = @id";
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            DiarioImpreso diario = new DiarioImpreso();
            while (reader.Read())
            {
                diario.DiarioID = (int)reader["DiarioID"];
                diario.Nombre = reader["Nombre"] as string;
            }
            return diario;
        }

        public static bool InsertDiario(DiarioImpreso diario)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"insert into DiarioImpreso(Nombre)
                                    values(@nombre)";
            command.Parameters.AddWithValue("@nombre", diario.Nombre);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)                
                return true;
            else
                return false;
        }

        public static bool UpdateDiario(DiarioImpreso diario)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"update DiarioImpreso set Nombre = @nombre where DiarioID = @diarioID";
            command.Parameters.AddWithValue("@nombre", diario.Nombre);
            command.Parameters.AddWithValue("@diarioID", diario.DiarioID);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
                return true;
            else
                return false;
        }

        public static bool DeleteDiario(int? id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"delete DiarioImpreso where DiarioID = @diarioID";
            command.Parameters.AddWithValue("@diarioID", id);
            connection.Open();
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
