using AwsCs.Services.StorageApi.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Uniciv.Api.Data;
using Uniciv.Api.Repositories;

namespace Uniciv.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get;  }
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FundoeInvestidor")));
            services.AddScoped<IFundoCapitalRepository, FundoCapitalRepository>();
            services.AddScoped<IInvestidorRepository, InvestidorRepository>();
            services.AddSwaggerConfiguration();
            services.AddControllers()
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
            
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*app.UseCors(config => {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });*/
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseSwaggerConfiguration();


        }
    }
}
