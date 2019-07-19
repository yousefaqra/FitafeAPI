using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FitafeAPI.Business.Infrastructure;
using FitafeAPI.Business.Manager;
using FitafeAPI.Web.Api.Model;
using FitafeAPI.Web.Api.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitafeAPI.Web.Api.Controllers
{
    [Route("employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        // GET: api/Employee
        [HttpGet]
        [Route("", Name = "GetAllEmployees_v1")]
        [ProducesResponseType(typeof(ResourceCollection<EmployeeResource>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var chronometer = new Stopwatch().StartNow();

            var result = await _employeeManager.GetEmployeesAsync();
            chronometer.Stop();
            return Ok(result);
        }

        // GET: api/Employee/5
        [HttpGet]
        [Route("{id:min(1)}", Name = "GetEmployeeById_v1")]
        [ProducesResponseType(typeof(EmployeeResource), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var resource = await _employeeManager.GetEmployeeEntityAsync(id);

            if (resource != null) return Ok(resource);
            ExceptionManager.ThrowItemNotFoundException(nameof(id), $"No employee found for ID: {id}");
            return NotFound();
        }

        [HttpPost]
        [Route("", Name = "CreateEmployee_v1")]
        [ProducesResponseType(typeof(EmployeeResource), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] EmployeeModel model)
        {
            var resource = await _employeeManager.CreateEmployeeAsync(model);
            var test = await _employeeManager.GetEmployeeEntityAsync(resource.ID);
            return Created("CreateEmployee_v1", resource);
        }

        //// PUT: api/Employee/5
        //[HttpPut("{id}")]
        //public async Task Put(int id, [FromBody] EmployeeModel employeeMode)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    _employeeManager.DeleteAsync(id);
        //}
    }
}
