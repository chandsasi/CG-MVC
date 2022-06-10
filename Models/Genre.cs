using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcMusicStore.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.
DatabaseGeneratedOption.None)]
        public int GenreId { get; set; }

        [Column(TypeName = "varchar")]
        public string GenreName { get; set; }

        [Column(TypeName = "varchar")]
        public string Description { get; set; }
        public List<Album> Albums { get; set; }

        //public string GenreName { get; set; }
    }
}