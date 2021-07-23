using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Omadiko.WebApp.Utilities
{
    public class Utilities
    {
        public static int CalculateAge(DateTime birth, DateTime? death)
        {
            if (!death.HasValue)
            {
                return DateTime.Now.Year - birth.Year;
            }
            else
            {
                return death.Value.Year - birth.Year;
            }
        }
    }
}