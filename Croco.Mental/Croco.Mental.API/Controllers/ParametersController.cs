using Croco.Mental.Domain.Enums;
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
    [Route("api/v1/parameters")]
    public class ParametersController : Controller
    {
        /// <summary>
        /// Get all possible parameters from requests.
        /// </summary>
        /// <remarks>Get all parameters.</remarks>
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

        /// <summary>
        /// Get all possible parameters from requests.
        /// </summary>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<string> Emotions = new List<string>
                {
                    "Interessadx",
                    "Nervosx",
                    "Entusiasmadx",
                    "Amedrontadx",
                    "Inspiradx",
                    "Ativx",
                    "Assustadx",
                    "Culpadx",
                    "Determinadx",
                    "Atormentadx"
                };

                List<string> values = new List<string>
                {
                    "Nada",
                    "Pouco",
                    "Moderadamente",
                    "Bastante",
                    "Extremamente"
                };

                List<string> permutations = new List<string>();

                foreach (var e in Emotions)
                {
                    foreach (var v in values)
                    {
                        permutations.Add(string.Format("Estou me sentindo {0} {1}", v, e));
                    }
                }

                return Ok(permutations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}