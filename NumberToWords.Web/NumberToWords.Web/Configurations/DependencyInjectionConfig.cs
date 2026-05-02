using NumberToWords.Web.Interfaces.NumberToWords;
using NumberToWords.Web.Services.NumberToWords;

namespace NumberToWords.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(
            this IServiceCollection services)
        {
            services.AddScoped<INumberToWordsService, NumberToWordsService>();

            return services;
        }
    }
}
