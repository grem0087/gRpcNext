using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GrpcRealtyService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                    .AddConsole()
                    .AddEventLog();
            });
            ILogger logger = loggerFactory.CreateLogger<Program>();

            CreateHostBuilder(args, logger).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, ILogger logger) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureKestrel(kestrelServerOptions =>
                    {
                        kestrelServerOptions.ListenLocalhost(8080,
                            listenOptions => listenOptions.Protocols = HttpProtocols.Http1);

                        kestrelServerOptions.ListenLocalhost(50051,
                            listenOptions => listenOptions.Protocols = HttpProtocols.Http2);

                        var serverCert = new X509Certificate2("Certs/testCert.pfx", "test");
                        //kestrelServerOptions.ConfigureHttpsDefaults(opt =>
                        //{
                        //    opt.ServerCertificate = serverCert;
                        //    opt.ClientCertificateMode = ClientCertificateMode.RequireCertificate;

                        //    // Verify that client certificate was issued by same CA as server certificate
                        //    opt.ClientCertificateValidation = (certificate, chain, errors) =>
                        //    {
                        //        logger.LogWarning($"Certificate checking status: {certificate.Issuer == serverCert.Issuer}");
                        //        return certificate.Issuer == serverCert.Issuer;
                        //    };
                        //});
                    });
                });
    }
}