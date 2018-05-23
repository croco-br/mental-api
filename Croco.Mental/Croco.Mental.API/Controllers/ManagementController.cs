using Croco.Mental.Domain.Enums;
using Croco.Mental.Domain.Interfaces.Services;
using Croco.Mental.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Croco.Mental.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/Management")]
    public class ManagementController : Controller
    {
        private readonly IManagementService _managementService;

        public ManagementController(IManagementService managementService)
        {
            _managementService = managementService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = _managementService.DeleteAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}