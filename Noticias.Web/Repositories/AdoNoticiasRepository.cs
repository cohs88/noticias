using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Noticias.Web.Interfaces;
using Noticias.Web.Models;

namespace Noticias.Web.Repositories
{
    public class AdoNoticiasRepository : INoticiasRepository
    {
        private readonly IConfiguration _config;
        public AdoNoticiasRepository(IConfiguration config)
        {
            _config = config;
        }
        private string GetConnectionString() => _config.GetConnectionString("Default");
        public async Task CreateNoticia(EditNoticiaViewModel model)
        {
            using (SqlConnection connection = new SqlConnection (GetConnectionString())) {
                SqlCommand command = new SqlCommand (NoticiasSQL.CreateNoticia, connection);
                await connection.OpenAsync ();

                command.Parameters.AddWithValue("@ID_Autor", model.AutorId);
                command.Parameters.AddWithValue("@Titulo_Noticia", model.Titulo);
                command.Parameters.AddWithValue("@Descripcion_Noticia", model.Descripcion);
                command.Parameters.AddWithValue("@Contenido_Noticia", model.Contenido);
                command.Parameters.AddWithValue("@Fecha_Noticia", model.FechaCreacion);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteNoticia(int id)
        {
            using (SqlConnection connection = new SqlConnection (GetConnectionString())) {
                SqlCommand command = new SqlCommand (NoticiasSQL.DeleteNoticia, connection);
                await connection.OpenAsync ();
            
                command.Parameters.AddWithValue("@ID_Noticia", id);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<IEnumerable<NoticiaModel>> GetHome()
        {
            List<NoticiaModel> noticias = new List<NoticiaModel> ();
            using (SqlConnection connection = new SqlConnection (GetConnectionString())) {
                SqlCommand command = new SqlCommand (NoticiasSQL.GetNoticias, connection);
                await connection.OpenAsync ();

                using (SqlDataReader reader = await command.ExecuteReaderAsync ()) {
                    while (await reader.ReadAsync ())
                    {
                        noticias.Add(BuildNoticiaModelFromReader(reader));
                    }
                }
            }

            return noticias;
        }

        private static NoticiaModel BuildNoticiaModelFromReader(SqlDataReader reader)
        {
            return new NoticiaModel
            {
                NoticiaId = Convert.ToInt32(reader["ID_Noticia"]),
                Titulo = reader["Titulo_Noticia"].ToString(),
                Descripcion = reader["Descripcion_Noticia"].ToString(),
                Contenido = reader["Contenido_Noticia"].ToString(),
                FechaCreacion = Convert.ToDateTime(reader["Fecha_Noticia"]),
                Autor = new AutorModel
                {
                    AutorId = Convert.IsDBNull(reader["ID_Autor"]) ? 0 : Convert.ToInt32(reader["ID_Autor"]),
                    Nombre = reader["Nombre_Autor"].ToString(),
                    Apellidos = reader["Apellido_Autor"].ToString()
                }
            };
        }

        public async Task<NoticiaModel> GetNoticia(int id)
        {
            using (SqlConnection connection = new SqlConnection (GetConnectionString())) {
                SqlCommand command = new SqlCommand (NoticiasSQL.GetNoticia, connection);
                await connection.OpenAsync ();

                command.Parameters.AddWithValue("@ID_Noticia", id);

                using (SqlDataReader reader = await command.ExecuteReaderAsync ()) {
                    while (await reader.ReadAsync ())
                    {
                        return BuildNoticiaModelFromReader(reader);
                    }
                }
            }

            return null;
        }

        public async Task UpdateNoticia(EditNoticiaViewModel model)
        {
            using (SqlConnection connection = new SqlConnection (GetConnectionString())) {
                SqlCommand command = new SqlCommand (NoticiasSQL.UpdateNoticia, connection);
                await connection.OpenAsync ();

                command.Parameters.AddWithValue("@ID_Autor", model.AutorId);
                command.Parameters.AddWithValue("@Titulo_Noticia", model.Titulo);
                command.Parameters.AddWithValue("@Descripcion_Noticia", model.Descripcion);
                command.Parameters.AddWithValue("@Contenido_Noticia", model.Contenido);
                command.Parameters.AddWithValue("@Fecha_Noticia", model.FechaCreacion);
                command.Parameters.AddWithValue("@ID_Noticia", model.NoticiaId);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}