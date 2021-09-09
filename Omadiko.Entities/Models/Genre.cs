using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Omadiko.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }

        [Required(ErrorMessage ="*Name required")]
        public string Kind { get; set; }


        //Navigation Properties
        public virtual ICollection<Album> Albums { get; set; }
    }
}