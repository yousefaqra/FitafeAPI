using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitafeAPI.Business.Persistence.Entities.UsersEntities;
using FitafeAPI.Web.Api.Resource;

namespace FitafeAPI.Business
{
    public static class EntityToResourceExtensions
    {
        public static EmployeeResource ConvertToEmployeeResource(
            Employee entity)
        {
            return entity != null
                ? new EmployeeResource
                {
                    ID = entity.ID,
                    ImagePath = entity.ImagePath,
                    Adress = entity.Adress,
                    EmailAdress = entity.EmailAdress,
                    City = entity.City,
                    ContactPhone = entity.ContactPhone,
                    Password = entity.Password,
                    FullName = entity.FullName,
                    DateOfBirth = entity.DateOfBirth,
                    Username = entity.Username,
                }
                : null;
        }
    }
}
