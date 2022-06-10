using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcMusicStore.Models
{
    public class Artist
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public int ArtistId { get; set; }

        [Column(TypeName = "varchar")]
        public string ArtistName { get; set; }
        public List<Album> Albums { get; set; }

    }
}