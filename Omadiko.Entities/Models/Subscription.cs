using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omadiko.Entities.Models
{
    public class Subscription
    {
        public Membership Membership { get; set; }
        public int Quantity { get; set; }

        public Subscription(Membership membership, int quantity)
        {
            Membership = membership;
            Quantity = quantity;
        }

    }
}
