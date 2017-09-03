using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using TestApp.Data.Abstractions;
using TestApp.Data.Abstractions.ModelRepositories;
using TestApp.Data.Mock;
using TestApp.Repositories;

namespace TestApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StorageContext>();
            services.AddSingleton(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IStorage), typeof(Storage));
            services.AddMvc(options =>
                {
                    options.FormatterMappings.SetMediaTypeMappingForFormat
                        ("xml", MediaTypeHeaderValue.Parse("application/xml"));
                    options.FormatterMappings.SetMediaTypeMappingForFormat
                        ("js", MediaTypeHeaderValue.Parse("application/json"));
                })
                .AddXmlSerializerFormatters();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
