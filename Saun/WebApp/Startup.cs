using Domain.Shop.BasketItems;
using Domain.Shop.Baskets;
using Domain.Shop.Brands;
using Domain.Shop.Cities;
using Domain.Shop.Countries;
using Domain.Shop.DeliveryTypes;
using Domain.Shop.OrderItems;
using Domain.Shop.Orders;
using Domain.Shop.OrderStatuses;
using Domain.Shop.Payments;
using Domain.Shop.PaymentTypes;
using Domain.Shop.People;
using Domain.Shop.Products;
using Domain.Shop.ProductTypes;
using Domain.Shop.Reviews;
using Domain.Shop.Roles;
using Domain.Shop.Statuses;
using Domain.Shop.Stock;
using Domain.Shop.Units;
using Domain.Shop.UserRoles;
using Domain.Shop.Users;
using Infra;
using Infra.Shop.BasketItems;
using Infra.Shop.Baskets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infra.Shop.Brands;
using Infra.Shop.Cities;
using Infra.Shop.Countries;
using Infra.Shop.DeliveryTypes;
using Infra.Shop.OrderItems;
using Infra.Shop.Orders;
using Infra.Shop.OrderStatuses;
using Infra.Shop.Payments;
using Infra.Shop.PaymentTypes;
using Infra.Shop.People;
using Infra.Shop.Products;
using Infra.Shop.ProductTypes;
using Infra.Shop.Reviews;
using Infra.Shop.Roles;
using Infra.Shop.Statuses;
using Infra.Shop.Stock;
using Infra.Shop.Units;
using Infra.Shop.UserRoles;
using Infra.Shop.Users;


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
                options.UseSqlServer("Server=localhost,1433; Database=sql1; User=sa;Password=<Password123.>"));
            services.AddDbContext<SaunaDbContext>(options =>
                options.UseSqlServer("Server=localhost,1433; Database=sql1; User=sa;Password=<Password123.>"));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            
            services.AddScoped<IBasketItemsRepository, BasketItemsRepository>();
            services.AddScoped<IBasketsRepository, BasketsRepository>();
            services.AddScoped<IBrandsRepository, BrandsRepository>();
            services.AddScoped<ICitiesRepository, CitiesRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<IDeliveryTypesRepository, DeliveryTypesRepository>();
            services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IOrderStatusesRepository, OrderStatusesRepository>();
            services.AddScoped<IPaymentsRepository, PaymentsRepository>();
            services.AddScoped<IPaymentTypesRepository, PaymentTypesRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductTypesRepository, ProductTypesRepository>();
            services.AddScoped<IReviewsRepository, ReviewsRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IStatusesRepository, StatusesRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IUnitsRepository, UnitsRepository>();
            services.AddScoped<IUserRolesRepository, UserRolesRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

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
