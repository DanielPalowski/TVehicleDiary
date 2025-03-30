using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VehicleDiary.Data;
using VehicleDiary.Middleware;
using VehicleDiary.Models;
using VehicleDiary.Repository;
using VehicleDiary.Services;

namespace VehicleDiary
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			
			//conn DB
			builder.Services.AddDbContext<AppDbContext>
				(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			//conn Identity ORM
			builder.Services.AddDefaultIdentity<IdentityUser>(options => {options.SignIn.RequireConfirmedAccount = false;})
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<AppDbContext>();

			//http
			builder.Services.AddHttpContextAccessor();


			//conn Repository
			builder.Services.AddScoped(typeof(IRepositoryCrud<>), typeof(CrudRepository<>));
			builder.Services.AddScoped<IRepositoryVehicle, VehicleRepository>();
            builder.Services.AddScoped(typeof(IRepositoryViews<>), typeof(ViewsRepository<>));

			//Services
            builder.Services.AddScoped<CountryService>();



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
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
