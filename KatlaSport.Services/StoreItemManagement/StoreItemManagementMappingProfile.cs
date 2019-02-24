namespace KatlaSport.Services.StoreItemManagement
{
    using AutoMapper;
    using DataAccessStoreItem = KatlaSport.DataAccess.ProductStore.StoreItem;

    public class StoreItemManagementMappingProfile : Profile
    {
        public StoreItemManagementMappingProfile()
        {
            CreateMap<DataAccessStoreItem, StoreItem>();
        }
    }
}
