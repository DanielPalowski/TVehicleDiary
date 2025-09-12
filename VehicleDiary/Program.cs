using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VehicleDiary.Application.Mappings;
using VehicleDiary.Application.Services;
using VehicleDiary.Infrastructure.Data;
using VehicleDiary.Infrastructure.Middleware;
using VehicleDiary.Infrastructure.Repositories;
using VehicleDiary.Core.Entities;
using Microsoft.AspNetCore.Mvc.Razor;
using VehicleDiary.Application.Services.Seeding;
using VehicleDiary.Application.Services.MapperService;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Core.Interfaces.Repositories;

namespace VehicleDiary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //New view engine
            builder.Services
                .AddControllersWithViews()
                .AddRazorOptions(options =>
                {
                    options.ViewLocationFormats.Clear();

                    // MVC View routes
                    options.ViewLocationFormats.Add("/Web/Views/{1}/{0}.cshtml");
                    options.ViewLocationFormats.Add("/Web/Views/Shared/{0}.cshtml");

                    // MVC Area rote
                    options.AreaViewLocationFormats.Add("/Web/Views/{2}/{1}/{0}.cshtml");

                    // Shared
                    options.AreaPageViewLocationFormats.Add("/Web/Views/Shared/{0}.cshtml"); 
                });




            //conn DB
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            Console.WriteLine($"Loaded ConnectionString: {connectionString}");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(" ConnectionString is NULL! Check appsettings.json and configuration setup.");
            }

            // Connecting to DB
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));




            //conn Identity ORM
            builder.Services.AddDefaultIdentity<IdentityUser>(options => { options.SignIn.RequireConfirmedAccount = false; })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            //http
            builder.Services.AddHttpContextAccessor();


            //conn Repository
            builder.Services.AddScoped(typeof(IRepositoryCrud<>), typeof(CrudRepository<>));
            builder.Services.AddScoped<IRepositoryVehicle, VehicleRepository>();
            builder.Services.AddScoped(typeof(IRepositoryViews<>), typeof(ViewsRepository<>));
            builder.Services.AddScoped<IRepositoryCarUsage, CarUsageRepository>();

            //Services
            builder.Services.AddScoped<CountryService>();
            builder.Services.AddScoped<IVehicleService, VehicleService>();
            builder.Services.AddScoped<IRepairService, RepairService>();
            builder.Services.AddScoped<IVignetteService, VignetteService>();
            builder.Services.AddScoped<IOilService, OilService>();
            builder.Services.AddScoped<IPetrolService, PetrolService>();
            builder.Services.AddScoped<ITireService, TireService>();
            builder.Services.AddScoped<ICarUsageService, CarUsageService>();
            builder.Services.AddScoped<IRepairService, RepairService>();
            builder.Services.AddScoped<IRepairVehicleService, RepairVehicleService>();

            //Mapper
            builder.Services.AddAutoMapper(typeof(Program));



            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //Seeding role a Users
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                RoleSeeding.SeedRolesAsync(services).Wait();
                UserSeeding.SeedingUsersAsync(services).Wait();

            }

            //SecurityMiddleware
            app.UseMiddleware<VehicleSecurityMiddleware>();



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Main}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
