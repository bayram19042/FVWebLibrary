using FluentValidation.AspNetCore;
using FVWeb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FVWeb
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
            
            services.AddControllersWithViews().AddFluentValidation(options=> {
                options.RegisterValidatorsFromAssemblyContaining<Startup>();
                //IValidator interfaceden implemente edilmiþ tüm classlarý içerir
            });
           
            // ya da services.AddSingleton<IValidator<Customer>,CustomerValidator>()
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; database=OrnekValidationDb; integrated security=true")  ;
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Customers}/{action=Index}/{id?}");
            });
        }
    }
}
