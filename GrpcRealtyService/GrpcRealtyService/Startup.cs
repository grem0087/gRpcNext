using GrpcRealtyService.Internals;
using GrpcRealtyService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GrpcRealtyService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            SymmetricSecurityKey SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("this is my custom Secret key for authnetication"));

            services.AddMvc();
            services.AddGrpc();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddGrpcReflection();
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
            {
                options.Audience = "IssuerAudience";
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateActor = false,
                    IssuerSigningKey = SecurityKey,
                    ValidateLifetime = true
                };
            });

            services.AddAuthorization();

            services.AddTransient<IRealtyService, RealtyService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseGrpcWeb();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<Services.GrpcRealtyService>().EnableGrpcWeb();
                endpoints.MapGrpcReflectionService();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Just another one gRPC service.");
                });
            });

        }
    }
}
