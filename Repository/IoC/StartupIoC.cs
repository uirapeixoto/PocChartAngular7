using Microsoft.Extensions.DependencyInjection;
using Repository.Context;
using Repository.Contract;
using Repository.Repository;
using Repository.Service;

namespace Repository.IoC
{
    public class StartupIoC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<DataContext>();

            #region Service
            services.AddScoped<IDataChartService, DataChartService>();
            #endregion

            #region Repository
            services.AddScoped<IChartRepository, ChartRepository>();
            services.AddScoped<IDataChartRepository, DataChartRepository>();
            services.AddScoped<IChartRepository, ChartRepository>();
            services.AddScoped<IRepositoryBase<object>, RepositoryBase<object>>();
            #endregion
        }
    }
}
