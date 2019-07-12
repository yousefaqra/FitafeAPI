using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Persistence.Entities.OrderEntities
{
    public class Status
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<StatusDetail> Statuses { get; set; }

    }
}
