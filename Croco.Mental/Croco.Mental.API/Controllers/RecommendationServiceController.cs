using Croco.Mental.Domain.Interfaces.Services;
using Croco.Mental.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Croco.Mental.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/recommendation")]
    public class RecommendationServiceController : Controller
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationServiceController(IRecommendationService recommendationService) => _recommendationService = recommendationService;

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
                return Ok(await _recommendationService.RecommendActions(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}