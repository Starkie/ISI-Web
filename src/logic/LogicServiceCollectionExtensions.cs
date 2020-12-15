namespace Microsoft.Extensions.DependencyInjection
{
    using Fotografos.Logic.Managers;

    public static class LogicServiceCollectionExtensions
    {
        /// <summary>
        ///     A service collection extension method for registering the managers from
        ///     Fotografos's logic.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The service collection with the configured managers.</returns>
        public static IServiceCollection AddFotografosServices(this IServiceCollection services)
        {
            services.AddScoped<ApplicationManager>();
            services.AddScoped<PhotographerManager>();

            return services;
        }
    }
}
