﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Croco.Mental.Domain.Interfaces.Services;
using Croco.Mental.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Croco.Mental.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/questionnaires")]

    public class QuestionnairesController : Controller
    {
        private readonly IQuestionnaireService _humorDataService;
        public QuestionnairesController(IQuestionnaireService humorDataService) => _humorDataService = humorDataService;

        /// <summary>
        /// Returns Humor Data as Json.
        /// </summary>
        /// <param name="id">entity id</param>
        /// <remarks>Get a humor data object from the database.</remarks>
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
                return Ok(await _humorDataService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Persists a humor data object.
        /// </summary>
        /// <param name="data">Entity</param>
        /// <remarks>Save humor data object in the database.</remarks>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> Save([FromBody]Questionnaire data)
        {
            try
            {
                return Ok(await _humorDataService.Save(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }        
        }

        /// <summary>
        /// Returns all humor data on database.
        /// </summary>
        /// <remarks>Get all humor data objects from the database.</remarks>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _humorDataService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}