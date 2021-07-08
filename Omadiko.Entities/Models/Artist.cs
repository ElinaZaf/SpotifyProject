
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Omadiko.Entities
{
    public class Artist
    {
        public int ArtistId { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhotoId { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }

        //Navigation Properties

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}