using Hangfire;
using Hangfire.SqlServer;
using Microsoft.OpenApi.Models;

namespace Hangfire_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHangfire(configuration => configuration
           .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
           .UseSimpleAssemblyNameTypeSerializer()
           .UseRecommendedSerializerSettings()
           .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
           {
               CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
               SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
               QueuePollInterval = TimeSpan.Zero,
               UseRecommendedIsolationLevel = true,
               DisableGlobalLocks = true
           }));
            builder.Services.AddHangfireServer(options =>
            {
                options.WorkerCount = Environment.ProcessorCount * 5;
            });

            builder.Services.AddControllers();// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Hangfire API",
                    Description = "An ASP.NET Core Web API for managing schedule background jobs.",
                    Contact = new OpenApiContact
                    {
                        Name = "Goto Hangfire Dashboard",
                        Url = new Uri("https://localhost:44384/dashboard")
                    }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Change `Back to site` link URL
            var options = new DashboardOptions { AppPath = "/swagger/index.html" };
            app.UseHangfireDashboard("/dashboard", options);

            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }
    }
}
