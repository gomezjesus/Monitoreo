using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MonitoreoModels;
using Newtonsoft.Json;
using Dapper;
namespace NewsDataAccess
{
    public class EventoRepository
    {
         //static string ConnectionString = "Data Source = .\\; Initial Catalog=Monitoreo; Integrated Security = True";
        static string ConnectionString = "Server=10.32.121.1;Database=Monitoreo;User Id=A01233540; Password=Jg3r@rdoB;";
        public static string GetEventos()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            //var e = connection.Query<Evento>("Select *from Evento").ToList();  
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "select *from Evento";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Evento> eventos = new List<Evento>();
            while (reader.Read())
            {
                Evento evento = new Evento();
                evento.EventID = (int)reader["EventID"];
                evento.Subject = reader["Subject"] as string;
                evento.Description = reader["Description"] as string;
                evento.Inicio = (DateTime)reader["Inicio"];
                evento.Fin = (DateTime)reader["Fin"];
                evento.Color = reader["Color"] as string;
                evento.IsFullDay = (bool)reader["IsFullDay"];
                eventos.Add(evento);
            }
            string json = JsonConvert.SerializeObject(eventos);
            return json;
        }

        public static bool AddEvento(Evento e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            DateTime inicio = DateTime.ParseExact(e.start, "dd/MM/yyyy HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
            DateTime fin = DateTime.ParseExact(e.end, "dd/MM/yyyy HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
            command.CommandText = @"insert into Evento(Subject,Description,Inicio,Fin,Color,IsFullDay)
                                    values(@sub,@desc,@inicio,@fin,@color,@fullday)";
            command.Parameters.AddWithValue("@sub", e.Subject);
            command.Parameters.AddWithValue("@desc", e.Description);
            command.Parameters.AddWithValue("@inicio",inicio );
            command.Parameters.AddWithValue("@fin", fin);
            command.Parameters.AddWithValue("@color", e.Color);
            command.Parameters.AddWithValue("@fullday", e.IsFullDay);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
                return true;
            else
                return false;
        }

        public static bool UpdateEvento(Evento e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"update Evento set Subject = @sub, Description = @desc, Inicio = @ini, Fin = @fin, Color=@color where EventID = @eID";
            DateTime inicio = DateTime.ParseExact(e.start, "dd/MM/yyyy HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
            DateTime fin = DateTime.ParseExact(e.end, "dd/MM/yyyy HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
            command.Parameters.AddWithValue("@sub", e.Subject);
            command.Parameters.AddWithValue("@desc", e.Description);
            command.Parameters.AddWithValue("@ini", inicio);
            command.Parameters.AddWithValue("@fin", fin);
            command.Parameters.AddWithValue("@color", e.Color);
            command.Parameters.AddWithValue("@eID", e.EventID);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
                return true;
            else
                return false;
        }

        public static bool DeleteEvent(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"delete Evento where EventID = @eID";
            command.Parameters.AddWithValue("@eID", id);
            connection.Open();
            int result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}