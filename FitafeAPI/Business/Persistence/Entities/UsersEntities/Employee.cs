using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Persistence.Entities.UsersEntities
{
    public class Employee : User
    {
        public bool Active { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<StatusDetail> StatusDetails { get; set; }

    }
}
