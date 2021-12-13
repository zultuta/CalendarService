using CalendarService.Core.Interfaces.Helpers;
using CalendarService.Core.Interfaces.Services.InfrastructureServices;
using CalendarService.Core.Models.Constants;
using CalendarService.Infrastructure.Data.DbContexts;
using CalendarService.Infrastructure.Helpers;
using CalendarService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarService.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureDBContext(this IServiceCollection services)
        {
            services.AddDbContext<CalendarServiceDbContext>(options =>
            {
                options.UseMySQL(AppSettings.DbConnectionString);
            });
        }

        public static void ResolveInfrastructureServices(this IServiceCollection services)
        {
            services.ConfigureDBContext();
            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddScoped<ICalendarServiceCommads, CalendarServiceCommads>();
            services.AddScoped<ICalendarServiceQueries, CalendarServiceQueries>();
        }
    }
}
