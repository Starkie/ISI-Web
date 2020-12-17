using System;
namespace Fotografos.Logic.Managers
{
    using System.Collections.Generic;
    using System.Linq;
    using Fotografos.Domain;
    using Fotografos.Persistence;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationManager
    {
        private readonly FotomixContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationManager"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ApplicationManager(FotomixContext context)
        {
            this.context = context;
        }

        public IEnumerable<Application> GetApplications()
        {
            return this.context.Applications;
        }

        public Application GetApplication(long id)
        {
            return this.context.Applications.Find(id);
        }

        public Application CreateApplication(Application application)
        {
            if (application.Date == default || string.IsNullOrEmpty(application.EquipmentDescription) ||
                string.IsNullOrEmpty(application.Resume) || application.PhotographerId == 0)
            {
                return null;
            }

            // Check that no application from the same photographer
            // was registered in the last 30 days.
            bool anyApplicationInLast30Days = this.context.Applications.AsNoTracking().ToList().Any(
                a => a.PhotographerId == application.PhotographerId &&
                (a.Date - application.Date).Duration() <= TimeSpan.FromDays(30)
            );

            if (anyApplicationInLast30Days)
            {
                return null;
            }

            // TODO: Make async.
            this.context.Applications.Add(application);
            this.context.SaveChanges();
            this.context.Entry(application).GetDatabaseValues();

            return application;
        }
    }
}
