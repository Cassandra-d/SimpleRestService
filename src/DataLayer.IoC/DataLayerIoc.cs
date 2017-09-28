using Autofac;
using DataLayer.Contract;
using DataLayer.Repositories;
using System.Net.Http;

namespace DataLayer.IoC
{
    public class DataLayerIoc
    {
        private DataLayerIoc()
        {
        }

        public static void Register(ContainerBuilder builder, string dataHost)
        {
            builder
                .Register<AlbumsRepository>(_ => new AlbumsRepository(_.Resolve<HttpClient>(), dataHost))
                .As<IAlbumsRepository>()
                .InstancePerRequest();

            builder
                .Register<UsersRepository>(_ => new UsersRepository(_.Resolve<HttpClient>(), dataHost))
                .As<IUsersRepository>()
                .InstancePerRequest();

            builder
                .Register<HttpClient>(_ => new HttpClient())
                .InstancePerLifetimeScope();
        }
    }
}
