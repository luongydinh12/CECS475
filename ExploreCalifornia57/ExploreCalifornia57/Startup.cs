using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ExploreCalifornia57.Models;
using Microsoft.EntityFrameworkCore;

namespace ExploreCalifornia57
{
    public class Startup
    {
        private readonly IConfiguration configuration57;

        public Startup(IConfiguration configuration57) {
            this.configuration57 = configuration57;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<FormattingService>();

            services.AddTransient <FeatureToggles57>(x => new FeatureToggles57 {
            DeveloperExceptions57 = configuration57.GetValue<bool>("FeatureToggles57:DeveloperExceptions57")
            });

            services.AddDbContext<BlogDataContext>(options => 
            {
                var connectionString57 = configuration57.GetConnectionString("BlogDataContext");
                options.UseSqlServer(connectionString57);
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, FeatureToggles57 features57)
        {
            app.UseExceptionHandler("/error.html");

            if (features57.DeveloperExceptions57)
            {
                app.UseDeveloperExceptionPage();
            }
            /*
            app.Use(async (context,next) =>
            {
                if (context.Request.Path.Value.StartsWith("/hello"))
                {
                    await context.Response.WriteAsync("Hello ASP.NET Core!");
                }
                await next();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(" How are you?");
            });*/

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.Contains("invalid"))
                    throw new Exception("ERROR!");

                await next();
            });

            app.UseMvc(routes57 =>
            {
                routes57.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}"
                    );
            });

            app.UseFileServer();
        }
    }
}
