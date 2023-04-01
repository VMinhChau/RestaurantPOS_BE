
using AutoMapper;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RestaurantPOS.Data;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Service;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
            //Add db vs service in container
            var connectString = builder.Configuration.GetConnectionString("connect");
            builder.Services.AddDbContext<RestaurantDbContext>(option =>
                        option.UseSqlServer(
                           connectString));
            builder.Services.AddIdentity<Customer, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<RestaurantDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant API", Version = "v1" });
            });
            builder.Services.AddTransient<ICRUDexample, CRUDexample>();
            builder.Services.AddTransient<IUserService, UserService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API V1");
            });

            app.Run();
        }
    }
}