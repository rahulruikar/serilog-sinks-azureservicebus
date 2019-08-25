using Microsoft.Azure.ServiceBus;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Text;
using System.Threading;

namespace Serilog.Sinks.AzureServiceBus
{
    /// <summary>
    /// Writes log events as records to an Azure ServiceBus queue.
    /// </summary>
    public class AzureServiceBusSink : ILogEventSink
    {
        readonly int _waitTimeoutInMilliseconds = Timeout.Infinite;
        readonly IQueueClient _queueClient;
        readonly IFormatProvider _formatProvider;

        public AzureServiceBusSink(
            IQueueClient queueClient,
            IFormatProvider formatProvider)
        {
            _queueClient = queueClient;
            _formatProvider = formatProvider;
        }

        /// <summary>
        /// Emit the provided log event to the sink.
        /// </summary>
        /// <param name="logEvent">The log event to write.</param>
        public void Emit(LogEvent logEvent)
        {
            var message = new Message(Encoding.UTF8.GetBytes(logEvent.RenderMessage(_formatProvider)));
            _queueClient.SendAsync(message).Wait(_waitTimeoutInMilliseconds);
        }    
    }
}