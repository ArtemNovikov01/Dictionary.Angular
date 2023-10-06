using Dictionary.Domain.Data.Models;
using Dictionary.Domain.Data.Repositories.Contract;
using Dictionary.Domain.Data.Repositories.Contracts;
using Dictionary.Domain.Services;
using Dictionary.Domain.Services.Contracts;
using Dictionary.Infrastructure.Data;
using Dictionary.Infrastructure.Repositoreis;
using Dictionary.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Dictionary.Web.Infrastructure.Configuration
{
    public static class ConfigureDomainService
    {
        public static IServiceCollection AddDomainService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
            services.AddService();
            services.AddInfrastructureServices(configuration);

            return services;
        }

        private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<DictionaryContext>(options => options.
            UseNpgsql(configuration.GetConnectionString("Dictionary")));

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IConfirmationDataRepository, ConfirmationDataRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IWordRepository, WordRepository>();

            return services;
        }

        private static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddTransient<IConfirmationDataService, ConfirmationDataService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IWordService, WordService>();

            return services;
        }

        private static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailConfiguaration>(configuration.GetSection("EmailProfile"));
            services.AddTransient<IMailManager, MailManager>();

            return services;
        }

    }
}
