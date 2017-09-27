using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;

namespace ApiGateway.Config
{
    internal class ApiLayerIoc
    {
        private ApiLayerIoc()
        {
        }

        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
    }
}
