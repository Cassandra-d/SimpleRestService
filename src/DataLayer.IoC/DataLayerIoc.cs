using Autofac;
using DataLayer.Contract;
using DataLayer.Repositories;

namespace DataLayer.IoC
{
    public class DataLayerIoc
    {
        private DataLayerIoc()
        {
        }

        public static void Register(ContainerBuilder builder)
        {
            builder
                .RegisterType<AlbumsRepository>()
                .As<IAlbumsRepository>()
                .InstancePerRequest();

            builder
                .RegisterType<UsersRepository>()
                .As<IUsersRepository>()
                .InstancePerRequest();
        }
    }
}
