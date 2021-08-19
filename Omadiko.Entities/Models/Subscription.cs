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
        public Membership Membership { get; set; }
        public int Quantity { get; set; }


        //Navigation Properties
        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }




        public Subscription(Membership membership, int quantity)
        {
            Membership = membership;
            Quantity = quantity;
        }

    }
}
