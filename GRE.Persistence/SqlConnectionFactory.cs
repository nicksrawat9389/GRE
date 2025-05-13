using GRE.Application;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Persistence
{
    internal sealed class SqlConnectionFactory(IConfiguration configuration) : ISqlConnectionFactory
    {
        private readonly IConfiguration _configuration = configuration;

        public SqlConnection CreateConnection()
        {
            string connectionString = _configuration.GetConnectionString("Default");

            return new SqlConnection(connectionString);
        }
    }
}
