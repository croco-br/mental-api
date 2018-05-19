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
    [Route("api/v1/Engine")]
    public class RecommendationEngineController : Controller
    {
        private readonly IRecommendationEngine _recommendationEngine;

        public RecommendationEngineController(IRecommendationEngine recommendationEngine) => _recommendationEngine = recommendationEngine;

        /// <summary>
        /// Recommend actions based on humor data.
        /// </summary>
        /// <param name="id">entity id</param>
        /// <remarks>Get a humor data object from the database.</remarks>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> GetById(int userId)
        {
            try
            {
                return Ok(await _recommendationEngine.RecommendActions(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}