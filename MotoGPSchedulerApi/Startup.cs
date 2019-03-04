using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using MotoGPSchedulerApi.Repository;
using System.IO;

namespace MotoGPSchedulerApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Cors policy
            services.AddCors(options => options
                .AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader())
            );

            services.AddMvc();

            // Add DbContext using SQL Server Provider
            services.AddDbContext<ApplicationContext>(options =>options
                .UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("MotoGpDatabase"))
            );

            // Add generic repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Add  static files to serve images through the API
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });
            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}
