using Croco.Mental.Domain.Interfaces.Services;
using Croco.Mental.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Croco.Mental.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) => _userService = userService;

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
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _userService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns Questionnaires of a user as Json.
        /// </summary>
        /// <param name="id">entity id</param>
        /// <remarks>Get a questionnaire object from the database.</remarks>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("{id}/questionnaires/")]
        public async Task<IActionResult> GetQuestionnairesById(int id)
        {
            try
            {
                return Ok(await _userService.GetQuestionnairesByUser(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns all users.
        /// </summary>
        /// <remarks>Gets users objects from the database.</remarks>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _userService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Insert a user in the database.
        /// </summary>
        /// <param name="id">entity id</param>
        /// <remarks>Set a user object in the database.</remarks>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> Save([FromBody]User user)
        {
            try
            {
                return Ok(await _userService.Save(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}