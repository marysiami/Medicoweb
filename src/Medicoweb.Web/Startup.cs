using System;
using System.Text;
using Medicoweb.Account;
using Medicoweb.Data;
using Medicoweb.Data.Models.Account;
using Medicoweb.Drug;
using Medicoweb.Hospital;
using Medicoweb.Pharmacy;
using Medicoweb.Visit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Medicoweb.Web
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<MedicowebDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    o => o.MigrationsAssembly("Medicoweb.Data")));

            ConfigureIdentity(services);

            ConfigureAuthentication(services);

            services.AddCors(options => options
                .AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowAnyOrigin()
                            .AllowCredentials();
                    }));

            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
            RegisterOmdleModules(services);
        }

        private static void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<MedicowebUser, MedicowebRole>()
                .AddEntityFrameworkStores<MedicowebDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            });
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]));
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(config =>
                {
                    config.RequireHttpsMetadata = false;
                    config.SaveToken = true;
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = signingKey,
                        ValidateLifetime = true,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true
                    };
                });
        }

        private void RegisterOmdleModules(IServiceCollection services)
        {
            // Register all projects DI            
            services.RegisterDataModule();
            services.RegisterAccountModule();
            services.RegisterHospitalModule();
            services.RegisterVisitModule();
            services.RegisterDrugModule();
            services.RegisterPharmacyModule();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment()) spa.UseAngularCliServer("start");
            });
        }

        private void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<MedicowebDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}