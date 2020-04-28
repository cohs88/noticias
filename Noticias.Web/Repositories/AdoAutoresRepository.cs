using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Noticias.Web.Interfaces;
using Noticias.Web.Models;

namespace Noticias.Web.Repositories {
    public class AdoAutoresRepository : IAutoresRepository {
        private readonly IConfiguration _config;
        public AdoAutoresRepository (IConfiguration config) {
            _config = config;

        }
        private string GetConnectionString() => _config.GetConnectionString("Default");
        public async Task CreateAutor (EditAutorViewModel autor) {
            using (SqlConnection connection = new SqlConnection (GetConnectionString())) {
                SqlCommand command = new SqlCommand (AutoresSQL.CreateAutor, connection);
                await connection.OpenAsync ();

                command.Parameters.AddWithValue("@Nombre_Autor", autor.Nombre);
                command.Parameters.AddWithValue("@Apellido_Autor", autor.Apellidos);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAutor (int autorId) {
            using (SqlConnection connection = new SqlConnection (GetConnectionString())) {
                SqlCommand command = new SqlCommand (AutoresSQL.DeleteAutor, connection);
                await connection.OpenAsync ();

                command.Parameters.AddWithValue("@ID_Autor", autorId);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<AutorModel> GetAutor (int autorId) {
            using (SqlConnection connection = new SqlConnection (GetConnectionString())) {
                SqlCommand command = new SqlCommand (AutoresSQL.GetAutor, connection);
                await connection.OpenAsync ();

                command.Parameters.AddWithValue("@ID_Autor", autorId);

                using (SqlDataReader reader = await command.ExecuteReaderAsync ()) {
                    while (await reader.ReadAsync ()) {
                        return new AutorModel{
                            AutorId = Convert.ToInt32 (reader["ID_Autor"]),
                            Nombre = reader["Nombre_Autor"].ToString (),
                            Apellidos = reader["Apellido_Autor"].ToString ()
                        };
                    }
                }
            }

            return null;
        }

        public async Task<IEnumerable<AutorModel>> GetAutores () {
            List<AutorModel> autores = new List<AutorModel> ();
            using (SqlConnection connection = new SqlConnection (GetConnectionString())) {
                SqlCommand command = new SqlCommand (AutoresSQL.GetAutores, connection);
                await connection.OpenAsync ();

                using (SqlDataReader reader = await command.ExecuteReaderAsync ()) {
                    while (await reader.ReadAsync ()) {
                        autores.Add (new AutorModel {
                            AutorId = Convert.ToInt32 (reader["ID_Autor"]),
                                Nombre = reader["Nombre_Autor"].ToString (),
                                Apellidos = reader["Apellido_Autor"].ToString ()
                        });
                    }
                }
            }

            return autores;
        }

        public async Task UpdateAutor (EditAutorViewModel autorViewModel) {
            using (SqlConnection connection = new SqlConnection (GetConnectionString())) {
                SqlCommand command = new SqlCommand (AutoresSQL.UpdateAutor, connection);
                await connection.OpenAsync ();

                command.Parameters.AddWithValue("@Nombre_Autor", autorViewModel.Nombre);
                command.Parameters.AddWithValue("@Apellido_Autor", autorViewModel.Apellidos);
                command.Parameters.AddWithValue("@ID_Autor", autorViewModel.AutorId);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}