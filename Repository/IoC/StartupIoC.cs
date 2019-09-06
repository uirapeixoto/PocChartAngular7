using Microsoft.Extensions.DependencyInjection;
using Repository.Contract;
using Repository.Repository;
using Repository.Service;

namespace Repository.IoC
{
    public class StartupIoC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Service
            services.AddScoped<IDataChartService, DataChartService>();
            #endregion

            #region Repository
            services.AddScoped<IDataChartRepository, DataChartRepository>();
            services.AddScoped<IChartRepository, ChartRepository>();
            #endregion
        }
    }
}
