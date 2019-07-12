using FitafeAPI.Business.Persistence.Entities.MenuEntites;
using FitafeAPI.Business.Persistence.Entities.RateEntities;
using FitafeAPI.Business.Persistence.Entities.UsersEntities;
using FitafeAPI.Business.Persistence.RateEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Persistence.RestaurantEntities
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Story { get; set; }
        public string Experince { get; set; }
        public string WhatWeDo { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string ContactPhone { get; set; }
        public string EmailAdress { get; set; }
        public int DeliveryRange { get; set; }
        public int DeliveryCharge { get; set; }
        public bool IsOpen { get; set; }
        public bool IsActive { get; set; }
        public Menu Menu { get; set; }
        public Owner Owner { get; set; }
        public ICollection<RestaurantRate> Rates { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
