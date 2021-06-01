using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleApp.Dbcontext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp
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
            services.AddDbContext<CanditateDbContext>(options =>
           options.UseSqlServer(
               Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();  
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt"); 
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "CourseDetails",
                    pattern: "Course",
                    defaults: new { controller = "Home", action = "Course" });

                endpoints.MapControllerRoute(
                    name: "Terms",
                    pattern: "TermsOfUse",
                    defaults: new { controller = "Home", action = "TermsOfUse" });

                endpoints.MapControllerRoute(
                    name: "FAQ",
                    pattern: "FAQ",
                    defaults: new { controller = "Home", action = "FAQ" });

                endpoints.MapControllerRoute(
                    name: "workwithus",
                    pattern: "workwithus",
                    defaults: new { controller = "Home", action = "WorkwithUs" });
                
                endpoints.MapControllerRoute(
                    name: "contactus",
                    pattern: "contactus",
                    defaults: new { controller = "Home", action = "contactus" });
                
                endpoints.MapControllerRoute(
                    name: "hirebrainchild",
                    pattern: "hirebrainchild",
                    defaults: new { controller = "Home", action = "HireBrainchild" });
                
                
                endpoints.MapControllerRoute(
                    name: "ourteam",
                    pattern: "ourteam",
                    defaults: new { controller = "Home", action = "OurTeam" });


                endpoints.MapControllerRoute(
                    name: "success",
                    pattern: "Success",
                    defaults: new { controller = "Home", action = "Success" });

                endpoints.MapControllerRoute(
                    name: "Client",
                    pattern: "partner-with-us",
                    defaults: new { controller = "BussinessDetails", action = "Create" });

                endpoints.MapControllerRoute(
                    name: "Mentor",
                    pattern: "join-as-mentor",
                    defaults: new { controller = "MentorDetails", action = "Create" });

                endpoints.MapControllerRoute(
                    name: "Candidate",
                    pattern: "join",
                    defaults: new { controller = "CandidateDetails", action = "Apply" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
