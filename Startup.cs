using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Movie_App
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Se encarga de hacer el mapeo con el fichero que hay en la carpeta wwwroot con la URL
            //app.UseDefaultFiles();

            // Es una funcion que sirve para crear una excepcion por la pantalla del navegador
            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            // Se encarga de servir el fichero estatico
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(x => 
            {
                x.MapRazorPages();
                
                x.MapControllerRoute(
                        name: "Default",
                        pattern: "{controller}/{action}/{id?}",
                        defaults: new { controller = "App", Action = "Index" });
            });
        }
    }
}
