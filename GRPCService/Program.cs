using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace GRPCService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var environment = webBuilder.GetSetting("ENVIRONMENT");

                    if(environment != "Local")
                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.Listen(IPAddress.Any, 5001, listenOptions =>
                        {
                            listenOptions.Protocols = HttpProtocols.Http2;
                            listenOptions.UseHttps(webBuilder.GetSetting("CertLocation"),
                                webBuilder.GetSetting("CertPass"));
                        });
                    });

                    webBuilder.UseStartup<Startup>();
                });
    }
}
