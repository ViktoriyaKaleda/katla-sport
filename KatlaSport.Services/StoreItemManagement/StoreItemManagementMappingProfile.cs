﻿namespace KatlaSport.Services.StoreItemManagement
{
    using AutoMapper;
    using DataAccessStoreItem = KatlaSport.DataAccess.ProductStore.StoreItem;

    public class StoreItemManagementMappingProfile : Profile
    {
        public StoreItemManagementMappingProfile()
        {
            CreateMap<DataAccessStoreItem, StoreItem>()
                .ForMember(i => i.ProductName, opt => opt.MapFrom(i => i.Product.Name))
                .ForMember(i => i.ProductCode, opt => opt.MapFrom(i => i.Product.Code))
                .ForMember(i => i.ProductCategoryCode, opt => opt.MapFrom(i => i.Product.Category.Code));

            CreateMap<UpdateStoreItemRequest, DataAccessStoreItem>();
        }
    }
}
