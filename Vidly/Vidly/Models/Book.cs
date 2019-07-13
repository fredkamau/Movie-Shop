using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime? DatePublished { get; set; }
        public string AuthorName { get; set; }
        public int NumberInStock { get; set; }
        public int ISBN { get; set; }
    }
}