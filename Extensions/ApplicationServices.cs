using Points_Of_Interest.Api.Repositories;
using Points_Of_Interest.Api.Services;

namespace Points_Of_Interest.Api.Extensions
{
    public static class ApplicationServices
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<POIServices>();
            services.AddTransient<POIRepository>();
        }
    }
}