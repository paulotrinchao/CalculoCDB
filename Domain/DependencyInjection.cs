using Domain.Interfaces;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IRentabilidadeService, RentabilidadeService>();
            services.AddScoped<ICdbCalculator, CdbCalculator>();
            services.AddScoped<IImposto, Imposto>();
            services.AddScoped<IFatorProvider, FatorProvider>();
            return services;
        }
    }
}
