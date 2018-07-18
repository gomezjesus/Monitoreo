using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using NewsModel;


namespace NewsDataAccess
{
    public class NewsRepository
    {
        //static string ConnectionString = "Data Source = .\\; Initial Catalog=Monitoreo; Integrated Security = True";
        static string ConnectionString = "Server=10.32.121.1;Database=Monitoreo;User Id=A01233540; Password=Jg3r@rdoB;";
        public static IEnumerable<Nota> GetNews()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"select n.Notaid,n.Titulo,n.Reportero,s.NombreSeccion, c.NombreCategoria, n.Fecha,
                                    n.Ubicacion, n.Relevancia,n.Archivo, n.Dimensiones, n.Precio, n.Privacidad, n.Tag, d.Nombre
                                    from Nota n, Categoria c, Seccion s, DiarioImpreso d
                                    where n.CategoriaID = c.CategoriaID and
                                    n.SeccionID = s.SeccionID and
                                    n.DiarioID = d.DiarioID 
                                    order by Fecha desc";
            SqlDataReader reader = command.ExecuteReader();
            List<Nota> notas = new List<Nota>();
            while (reader.Read())
            {
                Nota nota = new Nota();
                nota.Notaid = (int)reader["Notaid"];
                nota.Titulo = reader["Titulo"] as string;
                nota.Reportero = reader["Reportero"] as string;
                nota.Seccion = reader["NombreSeccion"] as string;
                nota.Categoria = reader["NombreCategoria"] as string;
                nota.Fecha = (DateTime)reader["Fecha"];
                nota.Ubicacion = reader["Ubicacion"] as string;
                nota.Relevancia = (int)reader["Relevancia"];              
                nota.Archivo = reader["Archivo"] as string;
                nota.Dimensiones = reader["Dimensiones"] as string;
                nota.Precio = reader["Precio"] as string;
                nota.Privacidad = Convert.ToChar(reader["Privacidad"]);
                nota.DiarioImpreso = reader["Nombre"] as string;
                nota.Tag = reader["Tag"] as string;
                notas.Add(nota);
            }
            connection.Close();
            return notas;
        }

        public static IEnumerable<Nota> FindNews(string keywords)
        {
            keywords = keywords.Trim();
            keywords =  keywords.Replace(',', '%');
            keywords = keywords.Insert(0, "%");
            keywords = keywords.Insert(keywords.Length, "%");
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"select n.Notaid,n.Titulo,n.Reportero,s.NombreSeccion, c.NombreCategoria, n.Fecha,
                                    n.Ubicacion, n.Relevancia,n.Archivo, n.Dimensiones, n.Precio, n.Privacidad, n.Tag, d.Nombre
                                    from Nota n, Categoria c, Seccion s, DiarioImpreso d
                                    where n.CategoriaID = c.CategoriaID and
                                    n.SeccionID = s.SeccionID and
                                    n.DiarioID = d.DiarioID and
                                    n.Tag like @tags
                                    order by Fecha desc";
            command.Parameters.AddWithValue("@tags", keywords);
            SqlDataReader reader = command.ExecuteReader();
            List<Nota> notas = new List<Nota>();
            while (reader.Read())
            {
                Nota nota = new Nota();
                nota.Notaid = (int)reader["Notaid"];
                nota.Titulo = reader["Titulo"] as string;
                nota.Reportero = reader["Reportero"] as string;
                nota.Seccion = reader["NombreSeccion"] as string;
                nota.Categoria = reader["NombreCategoria"] as string;
                nota.Fecha = (DateTime)reader["Fecha"];
                nota.Ubicacion = reader["Ubicacion"] as string;
                nota.Relevancia = (int)reader["Relevancia"];
                nota.Archivo = reader["Archivo"] as string;
                nota.Dimensiones = reader["Dimensiones"] as string;
                nota.Precio = reader["Precio"] as string;
                nota.Privacidad = Convert.ToChar(reader["Privacidad"]);
                nota.DiarioImpreso = reader["Nombre"] as string;
                nota.Tag = reader["Tag"] as string;
                notas.Add(nota);
            }
            connection.Close();
            return notas;
        }
        public static Nota GetNew(int? id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"select n.Notaid,n.Titulo,n.Reportero,s.NombreSeccion, c.NombreCategoria, n.Fecha,
                                    n.Ubicacion, n.Relevancia, n.Archivo, n.Dimensiones, n.Precio, n.Privacidad, n.Tag, d.Nombre
                                    from Nota n, Categoria c, Seccion s, DiarioImpreso d
                                    where n.CategoriaID = c.CategoriaID and 
                                    n.SeccionID = s.SeccionID and
                                    n.DiarioID = d.DiarioID and
                                    n.Notaid = @id";

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            Nota nota = new Nota();
            while (reader.Read())
           {               
                nota.Notaid = (int)reader["Notaid"];
                nota.Titulo = reader["Titulo"] as string;
                nota.Reportero = reader["Reportero"] as string;
                nota.Seccion = reader["NombreSeccion"] as string;
                nota.Categoria = reader["NombreCategoria"] as string;
                nota.Fecha = (DateTime)reader["Fecha"];
                nota.Ubicacion = reader["Ubicacion"] as string;
                nota.Relevancia = (int)reader["Relevancia"];                
                nota.Archivo = reader["Archivo"] as string;
                nota.Dimensiones = reader["Dimensiones"] as string;
                decimal precio = (decimal)reader["Precio"];
                nota.Precio = precio.ToString();
                nota.Privacidad = Convert.ToChar(reader["Privacidad"]);
                nota.DiarioImpreso = reader["Nombre"] as string;
                nota.Tag = reader["Tag"] as string;
            }
            connection.Close();
            return nota;
        }

        public static bool InsertNota(Nota nota)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();            
            command.CommandText = @"insert into Nota(Titulo,Reportero,SeccionID,CategoriaID,Fecha,Ubicacion,Relevancia,
                                    Archivo,Dimensiones,Precio,Privacidad,DiarioID,Tag)
                                    values(@titulo,@reportero,@seccion,@categoria,@fecha,@ubicacion,@relevancia,
                                   @archivo,@dimensiones,@precio,@privacidad,@diario,@tag)";
            command.Parameters.AddWithValue("@titulo", nota.Titulo);
            command.Parameters.AddWithValue("@reportero", nota.Reportero);
            command.Parameters.AddWithValue("@seccion", nota.SeccionID);
            command.Parameters.AddWithValue("@categoria", nota.CategoriaID);
            command.Parameters.AddWithValue("@fecha", nota.Fecha);
            command.Parameters.AddWithValue("@ubicacion", nota.Ubicacion);
            command.Parameters.AddWithValue("@relevancia", nota.Relevancia);            
            command.Parameters.AddWithValue("@archivo", nota.Archivo);
            command.Parameters.AddWithValue("@dimensiones", nota.Dimensiones);
            command.Parameters.AddWithValue("@precio", Convert.ToDecimal(nota.Precio));
            command.Parameters.AddWithValue("@privacidad", nota.Privacidad);
            command.Parameters.AddWithValue("@diario", nota.DiarioImpresoID);
            command.Parameters.AddWithValue("@tag", nota.Tag);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
                return true;
            else
                return false;
        }

        public static bool UpdateNota(Nota nota)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"update Nota 
                                    set Titulo = @titulo, Reportero = @reportero, SeccionID = @seccion, CategoriaID = @categoria,
                                    Fecha = @fecha, Ubicacion = @ubicacion, Relevancia = @relevancia, 
                                    Archivo = @archivo, Dimensiones = @dimensiones, Precio = @precio, Privacidad= @privacidad,
                                    Tag = @tag, DiarioID = @diario 
                                    where Notaid = @notaid";
            command.Parameters.AddWithValue("@titulo", nota.Titulo);
            command.Parameters.AddWithValue("@reportero", nota.Reportero);
            command.Parameters.AddWithValue("@seccion", nota.SeccionID);
            command.Parameters.AddWithValue("@categoria", nota.CategoriaID);
            command.Parameters.AddWithValue("@fecha", nota.Fecha);
            command.Parameters.AddWithValue("@ubicacion", nota.Ubicacion);
            command.Parameters.AddWithValue("@relevancia", nota.Relevancia);            
            command.Parameters.AddWithValue("@archivo", nota.Archivo);
            command.Parameters.AddWithValue("@dimensiones", nota.Dimensiones);
            command.Parameters.AddWithValue("@precio", nota.Precio);
            command.Parameters.AddWithValue("@privacidad", nota.Privacidad);
            command.Parameters.AddWithValue("@diario", nota.DiarioImpresoID);
            command.Parameters.AddWithValue("@notaid", nota.Notaid);
            command.Parameters.AddWithValue("@tag", nota.Tag);

            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
                return true;
            else
                return false;
        }

        public static bool DeleteNota(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"delete nota where Notaid = @id";
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
                return true;
            else
                return false;
        }
       
    }
}
