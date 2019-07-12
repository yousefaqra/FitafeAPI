using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Persistence.Entities.MenuEntites
{
    public class MenuSection
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
