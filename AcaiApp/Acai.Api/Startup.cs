using Acai.Application.AppServices;
using Acai.Application.Interfaces;
using Acai.Domain.Interfaces.Repositories;
using Acai.Domain.Interfaces.Services;
using Acai.Domain.Services;
using Acai.Infra.Context;
using Acai.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Acai.Api
{
    public class Startup
    {
        private const string CONECTION_STRING = "AcaiDbConnection";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<AcaiContext>(options => options.UseSqlServer(Configuration.GetConnectionString(CONECTION_STRING)));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericAppService<>), typeof(GenericAppService<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddTransient<ISaborAppService, SaborAppService>();
            services.AddTransient<ISaborService, SaborService>();
            services.AddTransient<ISaborRepository, SaborRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
