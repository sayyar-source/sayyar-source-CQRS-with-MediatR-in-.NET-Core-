using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Mediatr_Sample.DataLayer;
using Mediatr_Sample.Service.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Mediatr_Sample.Service;
using FluentValidation.AspNetCore;
using Mediatr_Sample.Service.Commands.Create;
using Mediatr_Sample.Service.Queries.FindAll;
using Mediatr_Sample.Service.Behavior;
using Mediatr_Sample.Models;

namespace Mediatr_Sample
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
            services.AddMvc().AddFluentValidation(cfg=>cfg.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddDbContext<ShopDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            services.AddAutoMapper(typeof(AppMapper).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateCustomerCommand).GetTypeInfo().Assembly);
           // services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LogingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<CreateCustomerCommand, CustomerDto>),typeof(CreateCustomerValidationBehavior<CreateCustomerCommand, CustomerDto>));
            // services.AddMediatR(typeof(CustomerFindAllQuery).GetTypeInfo().Assembly);
            
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
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
