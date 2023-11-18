using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using NLog;
using Utilities.Helpers;
using Utilities.Interfaces;
using Utilities;

namespace API.Movies
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // Logger config
            string basePath = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\netcoreapp3.1\\", "");
            configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();
            Configuration = configuration;
           // LogManager.LoadConfiguration(string.Concat(basePath, "nlog.config"));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            services.AddMvc(m =>
            {
                m.Filters.Add<ValidateModelFilterAttribute>();
            });


            //OAuth
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IWebRequestApi, WebRequestApi>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
