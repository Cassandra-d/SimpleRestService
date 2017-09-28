using Autofac;
using Autofac.Integration.WebApi;
using BusinessLayer.IoC;
using DataLayer.IoC;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(ApiGateway.Config.Startup))]

namespace ApiGateway.Config
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = ConfigureWepApi();

            ConfigureAutofac(config);

            ModelMapping.Configure();

            app.UseAutofacWebApi(config);

            app.UseWebApi(config);
        }

        private void ConfigureAutofac(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            ApiLayerIoc.Register(builder);
            BusinessLayerIoc.Register(builder);
            DataLayerIoc.Register(builder);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private HttpConfiguration ConfigureWepApi()
        {
            HttpConfiguration config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();
            return config;
        }
    }
}
