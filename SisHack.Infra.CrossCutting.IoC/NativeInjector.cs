using Microsoft.Extensions.DependencyInjection;
using SisHack.Application.Interfaces;
using SisHack.Application.Services;
using SisHack.Domain.Interfaces.Repositories;
using SisHack.Domain.Interfaces.UnitOfWork;
using SisHack.Domain.Shared.Interface.Notification;
using SisHack.Domain.Shared.Notifications;
using SisHack.Infrastructure.Context;
using SisHack.Infrastructure.Repositories;
using SisHack.Infrastructure.UnitOfWork;

namespace SisHack.Infra.CrossCutting.IoC
{
    public static class NativeInjector
    {
        #region Public Methods

        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<SisHackContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotifier, Notifier>();

            PeopleIocRegister(services);

            return services;
        }

        #endregion Public Methods

        #region Private Methods

        private static void PeopleIocRegister(IServiceCollection services)
        {
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IPeopleService, PeopleService>();
        }

        #endregion Private Methods
    }
}