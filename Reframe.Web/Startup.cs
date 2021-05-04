using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reframe.Dal;
using Reframe.Dal.Entities;
using Reframe.Dal.Roles;
using Reframe.Dal.SeedInterfaces;
using Reframe.Dal.SeedService;
using Reframe.Dal.SeedServices;

namespace Reframe.Web
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
            services.AddRazorPages();
            services.AddDbContext<ReframeDbContext>(
                option=>option.UseSqlServer(Configuration.GetConnectionString(nameof(ReframeDbContext)))
                );

            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<ReframeDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole(Roles.Administrator));
            });

            services.AddScoped<IRoleSeedService, RoleSeedService>()
                    .AddScoped<IUserSeedService, UserSeedService>();

            services.AddRazorPages(options => {
                options.Conventions.AuthorizeFolder("/Admin", "RequireAdministratorRole");
            });
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
