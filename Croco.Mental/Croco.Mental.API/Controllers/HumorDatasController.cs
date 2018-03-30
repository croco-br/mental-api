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

namespace Croco.Mental.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/humordatas")]
 
    public class HumorDatasController : Controller
    {
        private readonly IHumorDataBusiness _humorDataBusiness;
        public HumorDatasController(IHumorDataBusiness humorDataBusiness) => _humorDataBusiness = humorDataBusiness;

        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _humorDataBusiness.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(HumorData data)
        {
            return Ok(await _humorDataBusiness.Save(data));
        }
    }
}