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

namespace Croco.Mental.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/users")]
    public class UsersController : Controller
    {
        private readonly IHumorDataBusiness _userBusiness;
        public UsersController(IHumorDataBusiness userBusiness) => _userBusiness = userBusiness;

        /// <summary>
        /// Returns User as Json.
        /// </summary>
        /// <param name="id">entity id</param>
        /// <remarks>Get a user object from the database.</remarks>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                return Ok(await _userBusiness.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }          
        }
    }
}