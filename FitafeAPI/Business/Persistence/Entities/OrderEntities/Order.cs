using FitafeAPI.Business.Persistence.Entities.OrderEntities;
using FitafeAPI.Business.Persistence.Entities.UsersEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Persistence.Entities.OrderEntities
{
    public class Order
    {
        public int ID { get; set; }
        public string Note { get; set; }
        public ICollection<StatusDetail> Statuses { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<DeliveryAdress> DeliveryAdresses { get; set; }

    }
}
