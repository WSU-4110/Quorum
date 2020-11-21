using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quorum.Areas.Identity;
using Quorum.Data;
using QuorumDB;
using QuorumDB.Models;
using Microsoft.IdentityModel.Logging;
using Quorum.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace Quorum
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        private IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //The environment chooses between the correct db
            //Prod db is stored in secrets while dev is stored in appsettings.dev.json
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("quorum")));

            services.AddIdentity<AspNetUser, IdentityRole>(options => {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            if (Env.IsDevelopment())
                services.AddRazorPages().AddRazorRuntimeCompilation();
            else
                services.AddRazorPages();
            
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<AspNetUser>>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddSingleton<CircuitHandler>(new TrackingCircuitHandler());
            services.AddScoped<UserState>();

            services.AddSingleton<IDbAccess, DbAccess>();
            services.AddTransient<IUserData, UserData>();
            services.AddTransient<IForumData, ForumData>();
            services.AddTransient<IUserData, UserData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
               Path.Combine(Directory.GetCurrentDirectory(), "Photos" )),
                RequestPath = "/Photos"
            });

            if (Env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
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
                endpoints.MapControllers();
                endpoints.MapBlazorHub(options =>
                    options.ApplicationMaxBufferSize = 10 * 1024 * 1024
                );
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
