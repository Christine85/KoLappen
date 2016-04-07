using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using KoLappen.Models;

namespace KoLappen
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //Connection String
            var connString = @"Data Source=kolappen.database.windows.net;Initial Catalog=Projekt3;Integrated Security=False;User ID=AWAP3;Password=Woaow2016;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DBContext>(o => o.UseSqlServer(connString));

            //lagra användaren i databasen
            services.AddIdentity<IdentityUser, IdentityRole>(o =>
            {
                // krav på lösenordet
                o.Password.RequiredLength = 8;
                o.Password.RequireNonLetterOrDigit = false;
                o.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
            })
                .AddEntityFrameworkStores<IdentityDbContext>() //vart det skall lagras
                .AddDefaultTokenProviders(); //standard inställingar, regler för lösenord

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<IdentityDbContext>(o => o.UseSqlServer(connString));

            services.AddTransient<IAccountRepository, DbAccountRepository>();
            services.AddTransient<IProfileRepository, ProfileDataManager>();



            // Test
            //services.AddTransient<IPostsRepository, TestPostsRepository>();
            // Kopplat mot DB
            services.AddTransient<IPostsRepository, DbPostsRepository>();

            
            services.AddTransient<IEducationRepository, DbEducationRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();

            app.UseCookieAuthentication(o =>
            {
                o.AutomaticChallenge = true;
                //o.LoginPath = new PathString("/Members/Login/");
            });

            app.UseIdentity();
            app.UseMvcWithDefaultRoute();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
