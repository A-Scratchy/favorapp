namespace API
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Identity.Web;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Favor.API.Interfaces;
    using Favor.API.Containers;
    using Favor.OptionBindings;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(opt =>
                    {
                        Configuration.Bind("AzureAdB2C", opt);
                        opt.TokenValidationParameters.NameClaimType = "name";
                    },
                opt => { Configuration.Bind("AzureAdB2C", opt); });

            services.Configure<EndpointOptions>(Configuration.GetSection(EndpointOptions.SectionName));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            services.AddAuthorization(options =>
               {
                   options.AddPolicy("ValidId", policy => policy.RequireClaim("http://schemas.microsoft.com/identity/claims/objectidentifier"));
               });

            services.AddSingleton<ICandidateContainer, CandidateContainer>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
