using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Croco.Mental.Business.Interfaces;
using Croco.Mental.Business;
using Croco.Mental.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Croco.Mental.Domain.Enums;
using System.Reflection;

namespace Croco.Mental.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/Management")]
    public class ManagementController : Controller
    {
        private readonly IManagementBusiness _managementBusiness;

        public ManagementController(IManagementBusiness managementBusiness)
        {
            _managementBusiness = managementBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = _managementBusiness.DeleteAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}