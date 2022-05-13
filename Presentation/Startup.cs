using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Infrastructure.Persistence;
using Application;
using Infrastructure;
using Application.Common.Interfaces;
using Presentation.Services;
using Infrastructure.Identity;

namespace Presentation
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
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddHttpContextAccessor();            
 
            services.AddCors(options =>
            {
               var frontEndUrl = Configuration.GetValue<string>("frontEndUrl");

                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(frontEndUrl)
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            
            services.AddControllersWithViews();

            services.AddRazorPages();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = "JwtBearer";
            //    options.DefaultChallengeScheme = "JwtBearer";
            //})

            //.AddJwtBearer("JwtBearer", jwtBearerOptions =>
            //{
            //    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
            //    {                   
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HiddenFileName")),
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        ValidateLifetime = true,
            //        ClockSkew = TimeSpan.FromMinutes(5)
            //    };

            //    jwtBearerOptions.Authority = "https://localhost:5001";
            //    jwtBearerOptions.Audience = "api1";

            //}); 

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc(
                  "v1",
                  new OpenApiInfo
                  {
                      Title = "Ethiopia Api",
                      Version = "v1"
                  });
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseIdentityServer();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Ethiopia Api");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
