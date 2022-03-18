using AutoMapper;
using BookStore.Server.API.DtoHandlers;
using BookStore.Server.BLL.Interfaces;
using BookStore.Server.BLL.Services;
using BookStore.Server.DAL.EF;
using BookStore.Server.DAL.Interfaces;
using BookStore.Server.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;

namespace BookStore.Server.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(connection));

            services.AddControllers();

            services.AddMemoryCache();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICartItemRepository, CartItemRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICartItemService, CartItemService>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddTransient<ProductHandler>();
            services.AddTransient<OrderHandler>();

            services.AddSwaggerGen(config =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(config=>
            {
                config.RoutePrefix = string.Empty;
                config.SwaggerEndpoint("swagger/v1/swagger.json", "BookStore Api");
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
