using data;
using data.Repository;
using domain.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenceDesktop.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonServices(this IServiceCollection collection)
        {
            collection.AddDbContext<RemoteDatabaseContext>()
                .AddSingleton<IGroupRepository, GroupRepository>()
                .AddTransient<IGroupUseCase, GroupService>()
                .AddSingleton<IUserRepository, UserRepository>()
                .AddTransient<MainWindow>();
        }
    }
}
