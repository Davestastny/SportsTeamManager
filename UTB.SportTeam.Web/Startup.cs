using Microsoft.EntityFrameworkCore;
using UTB.SportTeam.Domain.Entities.Interfaces.Repository;
using UTB.SportTeam.Infrastructure.Database;
using UTB.SportTeam.Infrastructure.Repository;

namespace UTB.SportTeam.Web
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
            // Databáze – EF Core + MySQL (connection string je v appsettings.json)
            services.AddDbContext<SportTeamDbContext>(optionsBuilder =>
                optionsBuilder.UseMySQL(Configuration.GetConnectionString("MySql")!));

            // Generický Repository přijímá obecný DbContext → předáme mu náš SportTeamDbContext
            services.AddScoped<DbContext>(sp => sp.GetRequiredService<SportTeamDbContext>());
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddControllersWithViews();
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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
