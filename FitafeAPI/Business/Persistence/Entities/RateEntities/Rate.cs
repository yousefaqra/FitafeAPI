using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Persistence.RateEntities
{
    public class Rate
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int Value { get; set; }
    }
}
