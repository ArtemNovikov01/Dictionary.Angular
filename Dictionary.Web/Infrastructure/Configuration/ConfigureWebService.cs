using Dictionary.Web.Handlers;
using Dictionary.Web.Handlers.Contracts;
using Dictionary.Web.Infrastructure.Authorization;
using Dictionary.Web.Mappers;
using Dictionary.Web.Mappers.Contracts;
using Dictionary.Web.Validators.Authorization;
using Dictionary.Web.Validators.Authorization.Contracts;
using Dictionary.Web.Validators.Base;
using Dictionary.Web.Validators.Base.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Dictionary.Web.Infrastructure.Configuration
{
    public static class ConfigureWebService
    {
        public static IServiceCollection AddWebService(this IServiceCollection services)
        {
            services.AddAuthentication();
            services.AddHandlers();
            services.AddMappers();

            return services;
        }
        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<IUserHandler, UserHandler>();

            return services;
        }

        private static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddTransient<IAttemptInfoMapper, AttemptInfoMapper>();
            services.AddTransient<IUserMapper, UserMapper>();

            return services;
        }

        private static IServiceCollection AddAuthentication(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ISignInManager, SignInManager>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "Dictionary.AuthenticationToken";
                    options.ExpireTimeSpan = TimeSpan.FromHours(12);
                    options.SlidingExpiration = true;
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                            return Task.FromResult(0);
                        },
                        OnRedirectToAccessDenied = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;

                            return Task.FromResult(0);
                        }
                    };
                });
            return services;
        }
    }
}
