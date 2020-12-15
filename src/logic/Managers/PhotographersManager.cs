using System.Collections.Generic;
using Fotografos.Domain;
using Fotografos.Persistence;

namespace Fotografos.Logic.Managers
{
    public class PhotographerManager
    {
        private readonly FotomixContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhotographerManager"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public PhotographerManager(FotomixContext context)
        {
            this.context = context;
        }

        public IEnumerable<Photographer> GetPhotographers()
        {
            return this.context.Photographers;
        }

        public Photographer GetPhotographer(long id)
        {
            return this.context.Photographers.Find(id);
        }

        public Photographer CreatePhotographer(Photographer photographer)
        {
            if (string.IsNullOrEmpty(photographer.Name) ||
                string.IsNullOrEmpty(photographer.Surename) ||
                string.IsNullOrEmpty(photographer.Address) ||
                string.IsNullOrEmpty(photographer.City) ||
                photographer.Postalcode == 0 ||
                photographer.Telephone == 0)
            {
                return null;
            }

            // TODO: Make async.
            this.context.Photographers.Add(photographer);
            this.context.SaveChanges();
            this.context.Entry(photographer).GetDatabaseValues();

            return photographer;
        }
    }
}
