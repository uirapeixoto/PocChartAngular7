using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Repository.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection TemplateConnection
        {
            get
            {
                var result = _configuration.GetConnectionString("db");
                return new SqlConnection(result);
            }
        }
    }
}
