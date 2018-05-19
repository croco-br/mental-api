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
    [Route("api/v1/Parameters")]
    public class ParametersController : Controller
    {
        /// <summary>
        /// Get all possible parameters from requests.
        /// </summary>
        /// <param name="id">entity id</param>
        /// <remarks>Get a parameter.</remarks>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Object> list = new List<object>();
                var enumTypes = AppDomain.CurrentDomain.GetAssemblies()
                                            .SelectMany(x => x.GetTypes())
                                            .Where(x => x.IsEnum && x.Namespace == "Croco.Mental.Domain.Enums");

                foreach (Type t in enumTypes)
                {
                    list.Add(new
                    {
                        Parameter = t.Name,
                        Keys = t.GetEnumNames(),
                    });
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}