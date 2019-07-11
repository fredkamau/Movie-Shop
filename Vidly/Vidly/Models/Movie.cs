using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        //Navigation property
        public Genre Genre { get; set; }
        //foreign Key
        public byte GenreId { get; set; }
    }
}