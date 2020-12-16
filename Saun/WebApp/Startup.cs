using Domain.Brands;
using Domain.DeliveryTypes;
using Domain.ProductTypes;
using Domain.Products;
using Domain.Units;
using Infra;
using Infra.Brands;
using Infra.DeliveryCities;
using Infra.DeliveryCountries;
using Infra.DeliveryStatuses;
using Infra.DeliveryTypes;
using Infra.ProductTypes;
using Infra.Stocks;
using Infra.Products;
using Infra.Units;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Domain.Reviews;
using Domain.Roles;
using Domain.Stock;
using Domain.UserRoles;
using Infra.UserRoles;
using Infra.Roles;
using Infra.Reviews;
using Domain.Users;
using Infra.Users;


namespace WebApp
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<SaunaDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddScoped<IBrandsRepository, BrandsRepository>();
            services.AddScoped<IProductTypesRepository, ProductTypesRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IUnitsRepository, UnitsRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IDeliveryCountriesRepository, DeliveryCountriesRepository>();
            services.AddScoped<IDeliveryTypesRepository, DeliveryTypesRepository>();
            services.AddScoped<IDeliveryStatusesRepository, DeliveryStatusesRepository>();
            services.AddScoped<IDeliveryCitiesRepository, DeliveryCitiesRepository>();
            services.AddScoped<IReviewsRepository, ReviewsRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IUserRolesRepository, UserRolesRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
