using System;

using LearningBlazor.Data;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace LearningBlazor {

    public class Startup {

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            //services.AddSingleton(new DatabaseService(Configuration.GetConnectionString("DummyDb")));

            // local function
            void getDbContextOptions(DbContextOptionsBuilder options) {
                options.UseMySql(
                    Configuration.GetConnectionString("DummyEFDb"),
                    mySqlOptions => mySqlOptions
                    .ServerVersion(new Version(5, 7, 31), ServerType.MySql)
                    .CharSetBehavior(CharSetBehavior.NeverAppend));
                options.EnableSensitiveDataLogging(true);
            }
            //services.AddDbContext<AppDbContext>(options => getDbContextOptions(options));
            services.AddDbContext<TodoContext>(options => getDbContextOptions(options));
            services.AddDbContext<AuthorContext>(options => getDbContextOptions(options));

            //TodoContext.ConnectionString = Configuration.GetConnectionString("DummyEFDb");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}