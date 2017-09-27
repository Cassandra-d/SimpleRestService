using Autofac;
using BusinessLayer.Contract;

namespace BusinessLayer.IoC
{
    public class BusinessLayerIoc
    {
        private BusinessLayerIoc()
        {
        }

        public static void Register(ContainerBuilder builder)
        {
            builder
                .RegisterType<UsersService>()
                .As<IUsersService>()
                .InstancePerRequest();

            builder
                .RegisterType<AlbumsService>()
                .As<IAlbumsService>()
                .InstancePerRequest();
        }
    }
}
