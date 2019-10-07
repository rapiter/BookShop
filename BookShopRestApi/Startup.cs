using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Core.DomainService;
using BookShop.Infrastructure.SQLData;
using BookShop.Infrastructure.SQLData.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BookShopRestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration,IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
           // services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            if (Environment.IsDevelopment())
            {
                services.AddDbContext<BookShopAppContext>(
                      opt =>
                      {
                          opt.UseSqlite("Data Source=PetShopSQLite.db");
                      });
            }
            else
            {
                // Azure SQL database:
                services.AddDbContext<BookShopAppContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {

                    var ctx = scope.ServiceProvider.GetService<BookShopAppContext>();
                    //ctx.Database.EnsureCreated();
                    DbInitializer.SeedDB(ctx);

                }
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}