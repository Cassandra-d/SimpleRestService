namespace ApiGateway.Config
{
    // why not a separate project for each layer?
    // because this way will be easier to maintain bidirectional mappings if such would appear
    // and we already have references to Contract projects of each layer, aren't we?
    public class ModelMapping
    {
        private ModelMapping()
        {
        }

        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ApiLayerProfile>();
                cfg.AddProfile<BusinessLayerProfile>();
            });

            AutoMapper.Mapper.AssertConfigurationIsValid();
        }

        private class ApiLayerProfile : AutoMapper.Profile
        {
            public ApiLayerProfile()
            {
                CreateMap<BusinessLayer.Contract.Models.User, ApiGateway.Contract.Models.User>();
                CreateMap<BusinessLayer.Contract.Models.Album, ApiGateway.Contract.Models.Album>();
            }
        }

        private class BusinessLayerProfile : AutoMapper.Profile
        {
            public BusinessLayerProfile()
            {
                CreateMap<DataLayer.Contract.Models.Album, BusinessLayer.Contract.Models.Album>();
                CreateMap<DataLayer.Contract.Models.User, BusinessLayer.Contract.Models.User>();
            }
        }
    }
    
}
