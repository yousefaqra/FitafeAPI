using FitafeAPI.Business.Persistence.Entities.MenuEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Persistence.Entities.OrderEntities
{
    public class OrderItem
    {
        public int ID { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
