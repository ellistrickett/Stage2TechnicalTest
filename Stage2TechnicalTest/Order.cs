using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage2TechincalTest
{
    public class Order
    {
        public bool IsRushOrder { get; set; }
        public OrderType OrderType { get; set; }
        public bool IsNewCustomer { get; set; }
        public bool IsLargeOrder { get; set; }
    }

    public enum OrderType
    {
        Repair,
        Hire
    }

    public enum OrderStatus
    {
        Confirmed,
        Closed,
        AuthorisationRequired
    }
}
