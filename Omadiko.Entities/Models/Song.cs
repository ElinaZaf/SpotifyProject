using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Omadiko.Entities
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public string PhotoId { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime SongReleaseYear { get; set; }

        //Navigation Properties

        public virtual ICollection<Album> Albums { get; set; }
    }
}