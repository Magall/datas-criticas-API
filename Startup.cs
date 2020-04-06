using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading.Tasks;
using AutoMapper;
using DatasCriticasApi.Data;
using DatasCriticasApi.Mapper;
using DatasCriticasApi.Repository;
using DatasCriticasApi.Repository.IRepository;
using DatasCriticasApi.Services;
using DatasCriticasApi.Services.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DatasCriticasApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(opt =>
                 opt.UseNpgsql(Configuration.GetConnectionString("MyWebApiConection")));
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IDataCriticaRepository,DataCriticaRepository>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<IDataCriticaService, DataCriticaService>();
            services.AddAutoMapper(typeof(Mappings));
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("DatasOpenAPISpec", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Datas API",
                    Version = "1"
                });
            });
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:8080",
                                "https://localhost:8080")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/DatasOpenAPISpec/swagger.json", "Datas Criticas API");
                options.RoutePrefix = "";

            });
            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
