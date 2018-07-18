using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitoreoModels;
using System.Data.SqlClient;
namespace NewsDataAccess
{
    public class CategoriaRepository
    {
        //static string ConnectionString = "Data Source = .\\; Initial Catalog=Monitoreo; Integrated Security = True";
        static string ConnectionString = "Server=10.32.121.1;Database=Monitoreo;User Id=A01233540; Password=Jg3r@rdoB;";
        public static IEnumerable<Categoria> GetCategorias()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "Select *from Categoria";
            SqlDataReader reader = command.ExecuteReader();
            List<Categoria> categorias = new List<Categoria>();
            while (reader.Read())
            {
                Categoria categoria = new Categoria();
                categoria.CategoriaID = (int)reader["CategoriaID"];
                categoria.NombreCategoria = reader["NombreCategoria"] as string;
                categorias.Add(categoria);
            }
            return categorias;
        }

        public static Categoria GetCategoria(int? id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "Select * from Categoria where CategoriaID = @id";
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            Categoria categoria = new Categoria();

            while (reader.Read())
            {
                categoria.CategoriaID = (int)reader["CategoriaID"];
                categoria.NombreCategoria = reader["NombreCategoria"] as string;
            }
            return categoria;

        }

        public static bool InsertCategoria(Categoria categoria)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"insert into Categoria(NombreCategoria)
                                    values(@nombreCategoria)";
            command.Parameters.AddWithValue("@nombreCategoria", categoria.NombreCategoria);
            connection.Open();
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public static bool UpdateCategoria(Categoria categoria)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"update Categoria set NombreCategoria = @NombreCategoria where CategoriaID = @CategoriaID";
            command.Parameters.AddWithValue("@NombreCategoria", categoria.NombreCategoria);
            command.Parameters.AddWithValue("@CategoriaID", categoria.CategoriaID);
            connection.Open();
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public static bool DeleteCategoria(int? id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"delete Categoria where CategoriaID = @CategoriaID";
            command.Parameters.AddWithValue("@CategoriaID", id);
            connection.Open();
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
