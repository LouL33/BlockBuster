using Blockbuster.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blockbuster.Service
{
    public class MovieService
    {
        const string connectionString = @"Server=localhost\SQLEXPRESS;Database=BlockBuster;Trusted_Connection=True;";

        public List<Movie> GetAllMovies()
        {
            var rv = new List<Movie>();
            using (var connection = new SqlConnection(connectionString))
            {

                var text = @"SELECT * FROM Movies";
                var cmd = new SqlCommand(text, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Movie(reader));
                }
                connection.Close();
            }
            return rv;


        }


        public Movie CreateMovie(Movie Movie)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"INSERT INTO [dbo].[Movies]
                           ([Name]
                           ,[Year]
                           ,[Director]
                           ,[GenreId])                       
                            VALUES ( @Name, @Year, @Director, @GenreId)";
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", Movie.Name);
                cmd.Parameters.AddWithValue("@Year", Movie.Year);
                cmd.Parameters.AddWithValue("@Director", Movie.Director);
                cmd.Parameters.AddWithValue("@GenreId", (object)Movie.GenreId ?? DBNull.Value);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            return Movie;
        }
            
    }
}
