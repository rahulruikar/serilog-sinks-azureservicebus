# Serilog.Sinks.AzureServiceBus

Serilog.Sinks.AzureServiceBus is a Serilog sink that writes logs to a queue on Azure Service Bus.


## Installation

Using the dotnet cli:

```bash
dotnet add package Serilog.Sinks.AzureServiceBus
```

## Usage

To use with default settings, add the AzureServiceBus Sink using one of the following methods:

```c#
var connectionstring = "azure_service_bus_connection_string";
var queuename = "queue_name";

var log = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.AzureServiceBus(connectionstring, queue_name)
    .CreateLogger();

```



## Contributing

If you find a bug or have a feature request, please report them in this repository's issues section. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
Serilog.Sinks.AzureServiceBus is under Apache 2.0 License.

This library utilises the following libraries under the Apache 2.0 license, which can be obtained from http://www.apache.org/licenses/LICENSE-2.0.

- [Serilog](https://github.com/serilog/serilog/blob/dev/LICENSE)
- [Serilog.Formatting.Compact](https://github.com/serilog/serilog-formatting-compact/blob/dev/LICENSE)
