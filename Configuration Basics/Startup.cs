using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Configuration_Basics
{
    public class Startup
    {
        
        public Startup()
        {
            // строитель конфигурации
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    {"firstname", "Tom"},
                    {"age", "31"}
                });
            // создаем конфигурацию
            AppConfiguration = builder.Build();

        }
        public IConfiguration AppConfiguration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AppConfiguration["firstname"] = "alice";
            AppConfiguration["lastname"] = "simpson";
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"{AppConfiguration["firstname"]} {AppConfiguration["lastname"]} - {AppConfiguration["age"]}");
            });
        }
    }
}
