using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  FitafeAPI.Business.Persistence.Entities.UsersEntities
{
    public class Role
    {
        public int ID { get; set; }
        public bool Owner { get; set; }
        public bool Witer { get; set; }
        public bool Cheef { get; set; }
        public bool Delivery { get; set; }
    }
}
