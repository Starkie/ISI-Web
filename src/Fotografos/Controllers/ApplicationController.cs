namespace Fotogratos.Server.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Fotografos.Domain;
    using Fotografos.Logic.Managers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    ///     Controller for the <see cref="Application"/> entity.
    /// </summary>
    [ApiController]
    [Route("REST/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> logger;

        private readonly ApplicationManager applicationManager;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationController"/> class.
        /// </summary>
        /// <param name="logger"> The logger. </param>
        /// <param name="applicationManager"> The manager for the applications's logic. </param>
        public ApplicationController(ILogger<ApplicationController> logger, ApplicationManager applicationManager)
        {
            this.logger = logger;
            this.applicationManager = applicationManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Application>> GetApplications()
        {
            this.logger.LogInformation("Query for the applications");

            return this.applicationManager.GetApplications().ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<Application> GetApplication([FromRoute] long id)
        {
            this.logger.LogInformation($"Query for the application with id='{id}'");

            Application application = this.applicationManager.GetApplication(id);

            if (application is null)
            {
                return this.NotFound();
            }

            return this.Ok(application);
        }

        [HttpPost]
        public ActionResult<Application> CreateApplication([FromBody] Application application)
        {
            this.logger.LogInformation($"Creation of application - PhotographerId: {application.PhotographerId}");

            // TODO: Implement HTTP status errors.
            Application newApplication = this.applicationManager.CreateApplication(application);

            if (newApplication is null)
            {
                return this.Conflict("The application could not be submitted. Check that all the required data is filled; and check that the photographer hasn't submitted another application in the last 30 days.");
            }

            return newApplication;
        }

    }
}
