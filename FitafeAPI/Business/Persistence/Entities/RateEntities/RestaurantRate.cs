using FitafeAPI.Business.Persistence.Entities.UsersEntities;
using FitafeAPI.Business.Persistence.RateEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Persistence.Entities.RateEntities
{
    public class RestaurantRate : Rate
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
