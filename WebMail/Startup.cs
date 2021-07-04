using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebMail.Repositories;
using WebMail.Repositories.Interfaces;
using WebMail.Services;
using WebMail.Services.Interfaces;
using WebMail.Settings;

namespace WebMail
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
            services.AddControllers();

            // добавляем в класс MailSettings значения из appsettings.json
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            // подключение к БД
            services.AddTransient<IDbConnection>((sp) => new SqlConnection(Configuration.GetConnectionString("webmail2")));

            // СЕРВИСЫ
            services.AddTransient<IMailService, MailService>();

            // РЕПОЗИТОРИИ
            services.AddTransient<IMailRepository, MailRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
