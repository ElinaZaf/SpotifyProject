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
        public int Duration { get; set; }  //in sec
        public string AudioUrl { get; set; }
        public string VideoUrl { get; set; }
       

        //Navigation Properties
        public virtual ICollection<Album> Albums { get; set; }

        public string ConvertTime()
        {
            TimeSpan result = TimeSpan.FromSeconds(Duration);
            return String.Format($"{result.Minutes} min {result.Seconds} sec");
        }
    }
}