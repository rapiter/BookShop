﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Core.ApplicationService;
using BookShop.Core.ApplicationService.Implementation;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BookShopRestApi
{
    public class Startup
    {
       
            public Startup(IConfiguration configuration, IHostingEnvironment env)
            {
                Configuration = configuration;
                Environment = env;
            }

            public IConfiguration Configuration { get; }
            public IHostingEnvironment Environment { get; }
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
               
                if (Environment.IsDevelopment())
                {
                    services.AddDbContext<BookShopAppContext>(
                          opt =>
                          {
                              opt.UseSqlite("Data Source=BookShopSQLite.db");
                          });
                }
                else if(Environment.IsProduction())
                {
                    // Azure SQL database:
                    services.AddDbContext<BookShopAppContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                }

              services.AddScoped<IBookService, BookService>();
              services.AddScoped<IAuthorService, AuthorService>();
              services.AddScoped<ICustomerService, CustomerService>();
              services.AddScoped<IOrderService, OrderService>();
              services.AddScoped<IGenreService, GenreService>();
              services.AddScoped<IBookRepository, BookRepository>();
              services.AddScoped<IAuthorRepository, AuthorRepository>();
              services.AddScoped<IOrderRepository, OrderRepository>();
              services.AddScoped<ICustomerRepository, CustomerRepository>();
              services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddMvc().AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.MaxDepth = 3;
            });
            
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        .AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                    /* .WithOrigins("").AllowAnyHeader().AllowAnyMethod()
                     .WithOrigins("").AllowAnyHeader().AllowAnyMethod()
                     .WithOrigins("").AllowAnyHeader().AllowAnyMethod() */
                    ) ;
            });
            

        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
            app.UseCors("AllowSpecificOrigin");

            if (env.IsDevelopment())
                {
                 app.UseDeveloperExceptionPage();
                    using (var scope = app.ApplicationServices.CreateScope())
                    {
                        var ctx = scope.ServiceProvider.GetRequiredService<BookShopAppContext>();
                        ctx.Database.EnsureDeleted();
                        ctx.Database.EnsureCreated();
                        DbInitializer.SeedDB(ctx);

                    }
                }
                else if(env.IsProduction())
                {
                    app.UseHsts();
                    using (var scope = app.ApplicationServices.CreateScope())
                    {

                        var ctx = scope.ServiceProvider.GetRequiredService<BookShopAppContext>();
                        ctx.Database.EnsureCreated();
                        //  DbInitializer.SeedDB(ctx);
                    }
                }

                app.UseHttpsRedirection();
                app.UseMvc();
            }
        }
}