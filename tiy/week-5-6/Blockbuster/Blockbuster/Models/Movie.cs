using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blockbuster.Models
{
    public class Movie
    {
        //private FormCollection collection;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public int? GenreId { get; set; }


        public Movie() { }
        public Movie(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.Name = reader["Name"].ToString();
            this.Year = (int)reader["Year"];
            this.Director = reader["Director"].ToString();
            GenreId = reader["GenreId"] as int?;   
        }



    }
}