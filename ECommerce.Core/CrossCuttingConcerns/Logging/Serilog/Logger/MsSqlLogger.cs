using ECommerce.Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using ECommerce.Core.CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.CrossCuttingConcerns.Logging.Serilog.Logger
{
    public class MsSqlLogger : LoggerServiceBase
    {
        public MsSqlLogger(IConfiguration configuration)
        {
            var logConfiguration = configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration")
                .Get<MsSqlConfiguration>() ??
                throw new Exception(SerilogMessages.NullOptionsMessage);

            var sinkOpts = new MSSqlServerSinkOptions()
            {
                TableName = "Logs",
                AutoCreateSqlTable =true
            };

            var columnOpts = new ColumnOptions();
            columnOpts.Store.Remove(StandardColumn.Message);
            columnOpts.Store.Remove(StandardColumn.Properties);

            var serilogConfig = new LoggerConfiguration()  
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt")
                .WriteTo.MSSqlServer(
                connectionString: logConfiguration.ConnectionString,
                sinkOptions: sinkOpts,
                columnOptions: columnOpts)
                .WriteTo.Seq("http://localhost:5341/")
                .Enrich.FromLogContext()
                .CreateLogger();
            Logger = serilogConfig;
        }
    }
}
//Daha sonra daha da detaylandırılacaktır.