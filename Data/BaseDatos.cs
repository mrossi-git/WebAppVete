using Microsoft.Data.SqlClient;
using WebAppVete.Models;

namespace WebAppEncuesta.DB
{
    public class BaseDatos
    {
        private string conexionString = "Server=(localdb)\\mssqllocaldb;Database=Veterinaria;Trusted_Connection=True;MultipleActiveResultSets=True";


        public List<Especie> ObtenerEspecies(int especieBusq)
        {
            List<Especie> lista = new List<Especie>();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                string query = "SELECT * FROM Especies";
                if(especieBusq > 0)
                    query = "SELECT * FROM Especies WHERE id = " + especieBusq;

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Especie
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString()
                    });
                }
            }

            return lista;

        }
        public List<Mascota> ObtenerMascotas(int idBusqueda)
        {
            List<Mascota> lista = new List<Mascota>();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                string query = "SELECT * FROM Mascotas";
                if (idBusqueda > 0)
                    query = $"SELECT * FROM Mascotas WHERE id = {idBusqueda}";

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Mascota
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Propietario = reader["Propietario"].ToString(),
                        EspecieId = (int)reader["EspecieId"],
                        especie = ObtenerEspecies((int)reader["EspecieId"]).FirstOrDefault()
                    });
                }
            }

            return lista;
        }
        public string GuardarMascota(Mascota mascota)
        {
            List<Mascota> lista = new List<Mascota>();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                try
                {
                    string query = $"INSERT INTO Mascotas (Nombre, Propietario, EspecieId)";
                    query += $" VALUES ('{mascota.Nombre}', '{mascota.Propietario}', '{mascota.EspecieId}')";
                    
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteReader();
                }
                catch (Exception err)
                {
                    return err.Message;
                    throw;
                }
            }

            return "";
        }
    }
}
