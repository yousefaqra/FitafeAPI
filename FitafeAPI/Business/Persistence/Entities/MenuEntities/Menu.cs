using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Persistence.Entities.MenuEntites
{
    public class Menu
    {
        public int ID { get; set; }
        public ICollection<MenuSection> MenuSections { get; set; }
    }
}
