using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ZefixTest.Handlers;
using ZefixTest.Interfaces.Handlers;
using ZefixTest.Interfaces.Repositories;
using ZefixTest.Interfaces.Services;
using ZefixTest.Mappers;
using ZefixTest.Models.Context;
using ZefixTest.Repositories;
using ZefixTest.Services;

namespace ZefixTest
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZefixTest", Version = "v1" });
            });
            services.AddDbContext<ZefixContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(ZefixProviderProfile));
            AddScopedServices(services);
            AddTransientsServices(services);
        }

        private void AddScopedServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IZefixProviderHandler, ZefixProviderHandler>();
            services.AddScoped<IZefixCompanyHandler, ZefixCompanyHandler>();

            services.AddHttpClient<IZefixCompanyHandler, ZefixCompanyHandler>(client =>
            {
                client.BaseAddress = new Uri(Configuration["Providers:Zefix:baseUrl"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Configuration["Providers:Zefix:acceptedMimeType"]));
            })
            .SetHandlerLifetime(TimeSpan.FromMinutes(5));
        }

        private void AddTransientsServices(IServiceCollection services)
        {
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ICompanyService, CompanyService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZefixTest v1"));
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
