﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using Shop.Domain;
using Shop.Domain.Repositories.Implements;
using Shop.Domain.Repositories.Interfaces;
using Shop.Domain.SeedWork;
using Shop.Service.Implements;
using Shop.Service.Interfaces;
using System.Text;

namespace Shop.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(environment.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
              .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: false)
              .AddEnvironmentVariables();

            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel
                .Debug()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.RollingFile("./Loggings/log-{Date}.txt")
                .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<AeDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Dependency Injection for Repositories

            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();

            //services.AddScoped<IDiscountRepository, DiscountRepository>();
            //services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            //services.AddScoped<IFooterRepository, FooterRepository>();
            //services.AddScoped<IMenuRepository, MenuRepository>();
            //services.AddScoped<IMenuTypeRepository, MenuTypeRepository>();
            //services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();
            //services.AddScoped<IPaymentRepository, PaymentRepository>();
            //services.AddScoped<IPostCategoryRepository, PostCategoryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            //services.AddScoped<IPostTagRepository, PostTagRepository>();
            //services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IShippingProviderRepository, ShippingProviderRepository>();
            //services.AddScoped<IShippingRepository, ShippingRepository>();
            //services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            #endregion Dependency Injection for Repositories

            #region Dependency Injection for Services

            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IContactService, ContactService>();

            //services.AddScoped<IDiscountService, DiscountService>();
            //services.AddScoped<IFeedbackService, FeedbackService>();
            //services.AddScoped<IFooterService, FooterService>();
            //services.AddScoped<IMenuService, MenuService>();
            //services.AddScoped<IMenuTypeService, MenuTypeService>();
            //services.AddScoped<IOrderDetailService, OrderDetailService>();
            //services.AddScoped<IOrderService, OrderService>();
            //services.AddScoped<IPaymentService, PaymentService>();
            //services.AddScoped<IPostCategoryService, PostCategoryService>();
            services.AddScoped<IPostService, PostService>();
            //services.AddScoped<IPostTagService, PostTagService>();
            //services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<IShippingProviderService, ShippingProviderService>();
            //services.AddScoped<IShippingService, ShippingService>();
            //services.AddScoped<ITagService, TagService>();
            services.AddScoped<IUserService, UserService>();

            #endregion Dependency Injection for Services

            #region Authentication by JWT

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    TokenValidationParameters parameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };

                    options.TokenValidationParameters = parameters;
                });

            #endregion Authentication by JWT

            services.AddAutoMapper();

            #region Cors

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.WithOrigins("https://localhost:44377"));
            });

            #endregion Cors
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowMyOrigin");
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}