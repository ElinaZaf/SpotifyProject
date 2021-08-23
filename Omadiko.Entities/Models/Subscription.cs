using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omadiko.Entities.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentType { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }
        public List<SubscriptionDetails> SubscriptionDetails { get; set; }

        


    }
}
