using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeShop.Business.Abstract;
using FreeShop.Business.Concrete;
using FreeShop.DataAccess.Abstract;
using FreeShop.DataAccess.Concrete.EntityFramework;
using FreeShop.Entities.Concrete;

namespace FreeShop.WebUI
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
            services.AddControllersWithViews();
            //IManagerService gordugun yere ManagerService singleton mimarisine gore instance eder.
            //AddScoped bulundugu yerde singleton'i kullanir.
            //Transcient klasik instance'lama yontemi her seferinde ayri ayri instance yapar.
            services.AddSingleton<IManagerService, ManagerService>();
            services.AddSingleton<IManagerRepository, ManagerRepository>();

            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<IGenericRepository<Category>, CategoryRepository>();

            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IGenericRepository<Product>, ProductRepository>();

            services.AddSingleton<IProductCommentService, ProductCommentService>();
            services.AddSingleton<IGenericRepository<ProductComment>, ProductCommentRepository>();

            services.AddSingleton<IProductPhotoService, ProductPhotoService>();
            services.AddSingleton<IGenericRepository<ProductPhoto>, ProductPhotoRepository>();

            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IGenericRepository<User>, UserRepository>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            //Session
            services.AddSession();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //Session
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "adminroute",
                    areaName: "AdminPanel",
                    pattern: "admin",
                    defaults: new {controller="Admin", action="Login"});

                endpoints.MapAreaControllerRoute(
                    name: "admindashboard",
                    areaName: "AdminPanel",
                    pattern: "admin-dashboard",
                    defaults: new { controller = "AdminDashboard", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: "forgotpassword",
                    areaName: "AdminPanel",
                    pattern: "forgot-password",
                    defaults: new { controller = "Admin", action = "ForgotPassword" });

                endpoints.MapAreaControllerRoute(
                    name: "managers",
                    areaName: "AdminPanel",
                    pattern: "managers",
                    defaults: new { controller = "Admin", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: "newmanager",
                    areaName: "AdminPanel",
                    pattern: "new-manager",
                    defaults: new { controller = "Admin", action = "NewManager" });

                endpoints.MapAreaControllerRoute(
                    name: "managerphotoupload",
                    areaName: "AdminPanel",
                    pattern: "manager-photo-upload",
                    defaults: new { controller = "Admin", action = "PhotoUpload" });

                endpoints.MapAreaControllerRoute(
                    name: "adminproducts",
                    areaName: "AdminPanel",
                    pattern: "products",
                    defaults: new { controller = "Product", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: "adminproducts",
                    areaName: "AdminPanel",
                    pattern: "new-product",
                    defaults: new { controller = "Product", action = "NewProduct" }); 

                endpoints.MapAreaControllerRoute(
                    name: "adminphotoupload",
                    areaName: "AdminPanel",
                    pattern: "product-photo-upload",
                    defaults: new { controller = "Product", action = "ProductPhotoUpload" });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
