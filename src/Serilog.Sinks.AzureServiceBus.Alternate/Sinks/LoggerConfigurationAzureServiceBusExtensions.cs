using Microsoft.Azure.ServiceBus;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.AzureServiceBus;
using System;

namespace Serilog
{
    public static class LoggerConfigurationAzureServiceBusExtensions
    {
        public static LoggerConfiguration AzureServiceBus(
            this LoggerSinkConfiguration loggerConfiguration,
            string serviceBusConnectionString,
            string queueName,
            IFormatProvider formatProvider = null,
            LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum)
        {
            if (loggerConfiguration == null) throw new ArgumentNullException(nameof(loggerConfiguration));
            if (string.IsNullOrWhiteSpace(serviceBusConnectionString)) throw new ArgumentNullException(nameof(serviceBusConnectionString));
            if (string.IsNullOrWhiteSpace(queueName)) throw new ArgumentNullException(nameof(queueName));

            try
            {
                QueueClient client = new QueueClient(serviceBusConnectionString, queueName);
                return loggerConfiguration.Sink(new AzureServiceBusSink(client, formatProvider), restrictedToMinimumLevel);
            }
            catch (Exception ex)
            {
                Debugging.SelfLog.WriteLine($"Error configuring AzureServiceBus Sink");
                ILogEventSink sink = new LoggerConfiguration().CreateLogger();
                return loggerConfiguration.Sink(sink, restrictedToMinimumLevel);
            }
        }
    }
}
