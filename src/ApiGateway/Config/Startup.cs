using Autofac;
using Autofac.Integration.WebApi;
using BusinessLayer.IoC;
using Common;
using DataLayer.IoC;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(ApiGateway.Config.Startup))]

namespace ApiGateway.Config
{
    public class Startup
    {
        private const string DATA_HOST_CONFIG_KEY = "fake_data_host";

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = ConfigureWepApi();

            var dataHost = ConfigurationHelper.GetValue(DATA_HOST_CONFIG_KEY);
            ConfigureAutofac(config, dataHost);

            ModelMapping.Configure();

            app.UseAutofacWebApi(config);

            app.UseWebApi(config);
        }

        private void ConfigureAutofac(HttpConfiguration config, string dataHost)
        {
            var builder = new ContainerBuilder();

            ApiLayerIoc.Register(builder);
            BusinessLayerIoc.Register(builder);
            DataLayerIoc.Register(builder, dataHost);

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
