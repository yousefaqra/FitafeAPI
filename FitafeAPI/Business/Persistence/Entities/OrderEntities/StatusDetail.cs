using FitafeAPI.Business.Persistence.Entities.OrderEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Persistence.Entities
{
    public class StatusDetail
    {
        public DateTime TimeStamp { get; set; }
        public string Comment{ get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey("OrderStatus")]
        public int OrderStatusId { get; set; }
        public Status Status { get; set; }
    }
}
