using FitafeAPI.Business.Persistence.Entities.UsersEntities;
using FitafeAPI.Business.Persistence.Repositories;
using FitafeAPI.Web.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitafeAPI.Business.Infrastructure;
using FitafeAPI.Web.Api.Resource;

namespace FitafeAPI.Business.Manager
{
    public interface IEmployeeManager
    {
        Task<Employee> GetEmployeeEntityAsync(
            int id);

        Task<List<Employee>> GetEmployeesAsync();

        Task<int> GetEmployeesCountAsync();

        Task<EmployeeResource> CreateEmployeeAsync(
            EmployeeModel model);

        Task<EmployeeResource> UpdateEmployeeAsync(
            int assetId,
            int partyId,
            EmployeeModel model);

        Task<bool> DeleteEmployeeAsync(
            int assetId,
            int partyId);
    }

    public class EmployeeManager : IEmployeeManager
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeManager(IRepository<Employee> repository)
        {
            _repository = repository;
        }


        public Task<int> GetEmployeesCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeResource> CreateEmployeeAsync(
            EmployeeModel model)
        {
            // DB validation. 
            
            await ValidateEmployeeAsync(model);

            var entity = new Employee
            {
                Adress = model.Adress,
                EmailAdress = model.EmailAdress,
                City = model.City,
                Username = model.Username,
                DateOfBirth = model.DateOfBirth,
                FullName = model.FullName,
                ContactPhone = model.ContactPhone,
                ImagePath = model.ImagePath,
                Password = model.Password
            };

            await _repository.BeginTransactionAsync();

            _repository.Add(entity);

            await _repository.SaveAsync();

            var resource = EntityToResourceExtensions.ConvertToEmployeeResource(entity);

            return resource;
        }

        public Task<EmployeeResource> UpdateEmployeeAsync(int assetId, int partyId, EmployeeModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEmployeeAsync(int assetId, int partyId)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetEmployeeEntityAsync(
            int employeeId)
        {
            return await _repository.FirstOrDefaultAsync(x => x.ID == employeeId);
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return (await _repository.GetItemsAsync()).ToList();
        }

        private async Task ValidateEmployeeAsync(
            EmployeeModel model)
        {
            if (model == null)
            {
                ExceptionManager.ThrowInvalidModelException(nameof(EmployeeManager), "Request is invalid.");
                return;
            }

            var errors = model.ValidateModel();
            if (errors.Any())
            {
                ExceptionManager.ThrowInvalidModelException(errors);
            }
        }

    }
}
