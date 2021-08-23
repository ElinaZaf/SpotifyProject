using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omadiko.Entities.Models
{
    public class SubscriptionDetails
    {
        public int SubscriptionDetailsId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }


        //Navigation Properties
        public int SubscriptionId { get; set; }
        public virtual Subscription Subscription { get; set; }
        public int MembershipId { get; set; }
        public virtual Membership Membership { get; set; }
    }
}
