using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Omadiko.Entities
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string Url { get; set; }

        //Navigation Properties

        public virtual Artist Artist { get; set; }
    }
}