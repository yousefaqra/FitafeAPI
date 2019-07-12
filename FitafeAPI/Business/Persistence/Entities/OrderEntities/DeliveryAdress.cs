using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Persistence.Entities.OrderEntities
{
    public class DeliveryAdress
    {
        public int ID { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string PhoneNumer { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
