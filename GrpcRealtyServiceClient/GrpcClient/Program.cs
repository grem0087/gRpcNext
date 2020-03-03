using DowntownRealty;
using Grpc.Core;
using Grpc.Net.Client;
using IdentityModel;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GrpcClient
{
    class Program
    {

        static void Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            var certeficate = new X509Certificate2(basePath + "/Certs/testCert.pfx", "test");

            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            httpClientHandler.ClientCertificates.Add(certeficate);
            var httpClient = new HttpClient(httpClientHandler);
            var channel2 = GrpcChannel.ForAddress("http://localhost:50051");
            var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpClient = httpClient });
            var realtyServiceClient = new DowntownRealty.DowntownRealty.DowntownRealtyClient(channel);

            try
            {
                DoSimpleCall(realtyServiceClient);

                DoJwtCall(realtyServiceClient);
            }
            catch (RpcException ex)
            {

                throw;
            }
            catch (Exception ex)
            {

                throw;
            }

            Console.ReadLine();
        }

        private static void DoSimpleCall(DowntownRealty.DowntownRealty.DowntownRealtyClient realtyServiceClient)
        {
            var response = realtyServiceClient.GetRealtyById(new RealtyRequest { Id = 1 });
            var responseString = JsonConvert.SerializeObject(response);
            Console.WriteLine(responseString);
        }

        private static void DoJwtCall(DowntownRealty.DowntownRealty.DowntownRealtyClient realtyServiceClient)
        {
            var token = GenerateJwtToken();
            var headers = new Metadata();
            headers.Add("Authorization", $"Bearer {token}");

            var response = realtyServiceClient.GetRealtyList(new RealtyListRequest { Type = RealtyType.Any }, headers);
            var responseString = JsonConvert.SerializeObject(response);
            Console.WriteLine(responseString);
        }

        private static string GenerateJwtToken()
        {
            SymmetricSecurityKey SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("this is my custom Secret key for authnetication"));
            JwtSecurityTokenHandler JwtTokenHandler = new JwtSecurityTokenHandler();

            var claims = new[] {
                new Claim(JwtClaimTypes.Name, "ServiceClient"),
                new Claim(JwtClaimTypes.Issuer, "IssuerAudience"),
                new Claim(JwtClaimTypes.Audience, "IssuerAudience")
            };
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken("RealtyJwtServer", "ExampleClients", claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);
            return JwtTokenHandler.WriteToken(token);
        }
    }
}
