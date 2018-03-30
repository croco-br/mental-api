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

        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _userBusiness.GetById(id));
        }
    }
}