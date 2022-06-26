using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UsersControl.Data;
using UsersControl.Models;

namespace UsersControl
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
            // services.AddDbContext<UsersControlDbContext>(options => options.UseSql("InMemory"));
            services.AddDbContext<UsersControlDbContext>(options =>  options.UseSqlServer(Configuration.GetConnectionString("LoymarkDbContext")));
            services.AddScoped<IUserModelService, UserModelService>();
            services.AddScoped<ICountryModelService, CountryModelService>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 

            // app.UseHttpsRedirection();

            app.UseCors(builder => 
            {
                builder.AllowAnyHeader()
                       .WithOrigins(Configuration["AllowedOrigins"].Split(";").ToArray())
                       .WithMethods("GET", "POST", "PUT", "DELETE")
                       .Build();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
