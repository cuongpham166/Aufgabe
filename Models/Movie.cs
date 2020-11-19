using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieData.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Image Url")]
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Overview { get; set; }
        [Required]
        public int Score { get; set; }

    }
}
