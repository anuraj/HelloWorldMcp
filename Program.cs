#!/usr/bin/env dotnet
#:package Microsoft.Extensions.Hosting@10.0.1
#:package ModelContextProtocol@0.5.0-preview.1

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<EchoTool>();

builder.Logging.AddConsole(options =>
{
    options.LogToStandardErrorThreshold = LogLevel.Trace;
});

await builder.Build().RunAsync();

// File-scoped tool class
[McpServerToolType]
file class EchoTool
{
    [McpServerTool(Name = "echo"), Description("Echoes the message back to the client.")]
    public static string Echo([Description("The message to echo back.")] string message) => $"Echo: {message}";
}