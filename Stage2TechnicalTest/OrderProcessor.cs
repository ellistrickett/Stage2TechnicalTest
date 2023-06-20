using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Stage2TechincalTest
{
    public class OrderProcessor
    {
        private readonly Dictionary<(bool, OrderType, bool, bool), OrderStatus> statusMappings;

        public OrderProcessor()
        {
            statusMappings = new Dictionary<(bool, OrderType, bool, bool), OrderStatus>
            {
                { (true, OrderType.Repair, true, true), OrderStatus.Closed },
                { (false, OrderType.Repair, true, true), OrderStatus.Closed },

                { (true, OrderType.Repair, false, true), OrderStatus.Closed },
                { (true, OrderType.Hire, true, true), OrderStatus.Closed },
                { (true, OrderType.Hire, false, true), OrderStatus.Closed },

                { (false, OrderType.Repair, false, true), OrderStatus.AuthorisationRequired },

                { (true, OrderType.Repair, true, false), OrderStatus.AuthorisationRequired },
                { (true, OrderType.Repair, false, false), OrderStatus.AuthorisationRequired },
                { (true, OrderType.Hire, true, false), OrderStatus.AuthorisationRequired },
                { (true, OrderType.Hire, false, false), OrderStatus.AuthorisationRequired },

                { (false, OrderType.Repair, false, false), OrderStatus.Confirmed },
                { (false, OrderType.Repair, true, false), OrderStatus.Confirmed },
                { (false, OrderType.Hire, false, false), OrderStatus.Confirmed },
                { (false, OrderType.Hire, true, false), OrderStatus.Confirmed },
            };
        }

        public OrderStatus ProcessOrder(Order order)
        {
            var key = (order.IsRushOrder, order.OrderType, order.IsNewCustomer, order.IsLargeOrder);

            if (statusMappings.TryGetValue(key, out OrderStatus status))
            {
                return status;
            }

            throw new Exception("Mapping not found for the given combination of inputs.");
        }
    }
}
