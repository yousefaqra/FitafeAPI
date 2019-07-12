using FitafeAPI.Business.Persistence.Entities.RateEntities;
using FitafeAPI.Business.Persistence.RateEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Persistence.Entities.MenuEntites
{
    public class Meal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TotalCalories { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ICollection<Item> Items { get; set; }
        public int MenuSectionId { get; set; }
        public MenuSection MenuSection { get; set; }
        public ICollection<OrderRate> Rates { get; set; }
    }
}
