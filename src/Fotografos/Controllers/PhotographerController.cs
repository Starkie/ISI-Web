namespace Fotogratos.Server.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Fotografos.Domain;
    using Fotografos.Logic.Managers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    ///     Controller for the <see cref="Photographer"/> entity.
    /// </summary>
    /// [ApiController]
    [Route("REST/[controller]")]
    public class PhotographerController : ControllerBase
    {
        private readonly ILogger<ApplicationController> logger;

        private readonly PhotographerManager photographerManager;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationController"/> class.
        /// </summary>
        /// <param name="logger"> The logger. </param>
        /// <param name="photographerManager"> The manager for the photographers's logic. </param>
        public PhotographerController(ILogger<ApplicationController> logger, PhotographerManager photographerManager)
        {
            this.logger = logger;
            this.photographerManager = photographerManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Photographer>> GetPhotographers()
        {
            this.logger.LogInformation("Query for the photographers");

            return this.photographerManager.GetPhotographers().ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<Application> GetPhotographer([FromRoute] long id)
        {
            this.logger.LogInformation($"Query for the photographer with id='{id}'");

            Photographer photographer = this.photographerManager.GetPhotographer(id);

            if (photographer is null)
            {
                return this.NotFound();
            }

            return this.Ok(photographer);
        }

        [HttpPost]
        public ActionResult<Photographer> CreatePhotographer([FromBody] Photographer photographer)
        {
            this.logger.LogInformation($"Creation of phographer - Id: {photographer.Id} Name - {photographer.Name}");

            // TODO: Implement HTTP status errors.
            return this.photographerManager.CreatePhotographer(photographer);
        }

    }
}
