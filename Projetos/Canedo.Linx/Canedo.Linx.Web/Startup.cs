using Canedo.Linx.Fidelidade.ApiService.Service;
using Canedo.Linx.Fidelidade.Data.Context;
using Canedo.Linx.Fidelidade.Data.Repository.Dapper;
using Canedo.Linx.Fidelidade.Data.Repository.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Linq;
using System.Xml;

namespace Canedo.Linx.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<ConsultarFidelizacaoService>();
            services.AddSingleton<FidelidadeDbContext>();
            services.AddSingleton<IntegracaoDapperRepository>();
            services.AddSingleton<FidelizacaoDapperRepository>();
            services.AddSingleton<FidelizacaoEfRepository>();
            services.AddSingleton<IntegracaoEfRepository>();
            var fidelidadeDbContext = services.BuildServiceProvider().GetService<FidelidadeDbContext>();

            if (fidelidadeDbContext.Database.EnsureCreated())
            {
                fidelidadeDbContext.Integracoes.Add(new Fidelidade.Domain.Entity.Integracao() { ChaveIntegracao = "4B335B6F-9C4D-47F7-B798-C46FFBC4881A", CodigoLoja = "1" });
                fidelidadeDbContext.SaveChanges();
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            XmlDocument xmldoc = new XmlDocument();

            xmldoc.Load($@"{((PhysicalFileProvider)env.ContentRootFileProvider).Root}{env.ApplicationName}.csproj");

            var userSecretId = xmldoc.SelectSingleNode("//UserSecretsId")?.InnerText ?? string.Empty;

            if (userSecretId.Any())
            {
                new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .AddUserSecrets(userSecretId)
                .Build();
            }

            
        }
    }
}
