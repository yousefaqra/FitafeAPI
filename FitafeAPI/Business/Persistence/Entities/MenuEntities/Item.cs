using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Persistence.Entities.MenuEntites
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int Calaroies { get; set; }
        public string Description { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
