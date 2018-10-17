using CN.Taverna.Domain.Interfaces.Repositories;
using CN.Taverna.Domain.Interfaces.Services;
using CN.Taverna.Domain.Services;
using CN.Taverna.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CN.Taverna.API
{
    public static class Setup
    {

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            services.AddTransient(typeof(IUsuarioService), typeof(UsuarioService));

            services.AddTransient(typeof(IEspecialidadeRepository), typeof(EspecialidadeRepository));
            services.AddTransient(typeof(IEspecialidadeService), typeof(EspecialidadeService));

            services.AddTransient(typeof(IHeroiRepository), typeof(HeroiRepository));
            services.AddTransient(typeof(IHeroiService), typeof(HeroiService));

            services.AddTransient(typeof(IBatalhaRepository), typeof(BatalhaRepository));
            services.AddTransient(typeof(IBatalhaService), typeof(BatalhaService));
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Corvo Negro Game API",
                    Version = "v1",
                    Description = "A simple documentation from API Corvo Negro Game",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Anderson Olliver",
                        Email = "pla.olliver@gmail.com",
                        Url = "https://twitter.com/Olliverrrr_"
                    }
                });
                c.DescribeAllEnumsAsStrings();
            });
        }
    }
}
