using FitafeAPI.Business.Persistence.Entities.OrderEntities;
using FitafeAPI.Business.Persistence.Entities.RateEntities;
using FitafeAPI.Business.Persistence.RateEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Persistence.Entities.UsersEntities
{
    public class Customer : User
    {
        public int NumberOfOrders { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<OrderRate> OrderRates { get; set; }
        public ICollection<RestaurantRate> RestaurntRates { get; set; }
    }
}
