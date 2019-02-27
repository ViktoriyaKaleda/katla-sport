using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductCatalogue;
using KatlaSport.DataAccess.ProductStore;
using KatlaSport.DataAccess.ProductStoreHive;
using DbStoreItem = KatlaSport.DataAccess.ProductStore.StoreItem;

namespace KatlaSport.Services.StoreItemManagement
{
    public class StoreItemService : IStoreItemService
    {
        private readonly IProductStoreContext _storeItemContext;
        private readonly IProductCatalogueContext _productContext;
        private readonly IProductStoreHiveContext _categoryContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreItemService"/> class with specified <see cref="IProductStoreContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IProductStoreContext"/>.</param>
        /// /// <param name="productContext">A <see cref="IProductCatalogueContext"/>.</param>
        /// <param name="sectionContext">A <see cref="IProductStoreHiveContext"/>.</param>
        public StoreItemService(IProductStoreContext context, IProductCatalogueContext productContext, IProductStoreHiveContext sectionContext)
        {
            _storeItemContext = context ?? throw new ArgumentNullException(nameof(context));
            _productContext = productContext ?? throw new ArgumentNullException(nameof(productContext));
            _categoryContext = sectionContext ?? throw new ArgumentNullException(nameof(sectionContext));
        }

        /// <inheritdoc/>
        public async Task<StoreItem> GetStoreItemAsync(int storeItemId)
        {
            var dbStoreItems = await _storeItemContext.Items.Where(i => i.Id == storeItemId).ToArrayAsync();
            if (dbStoreItems.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbStoreItem, StoreItem>(dbStoreItems[0]);
        }

        /// <inheritdoc/>
        public async Task<List<StoreItem>> GetHiveSectionStoreItemsAsync(int hiveSectionId)
        {
            var dbHiveSections = await _storeItemContext.Items.Where(i => i.HiveSectionId == hiveSectionId && i.Quantity > 0).OrderBy(i => i.Id).ToArrayAsync();
            var hiveSections = dbHiveSections.Select(i => Mapper.Map<StoreItem>(i)).ToList();
            return hiveSections;
        }

        /// <inheritdoc/>
        public async Task<StoreItem> CreateStoreItemAsync(UpdateStoreItemRequest createRequest)
        {
            var dbProduct = _productContext.Products.Where(p => p.Id == createRequest.ProductId).FirstOrDefault();
            if (dbProduct == null)
            {
                throw new RequestedResourceHasConflictException("Product");
            }

            var dbAllowedSectionCatagegories = _categoryContext.Categories.Where(c => c.StoreHiveSectionId == createRequest.HiveSectionId && c.ProductCategoryId == dbProduct.Category.Id).FirstOrDefault();
            if (dbAllowedSectionCatagegories == null)
            {
                throw new RequestedResourceHasConflictException("Unallowable product category for this hive section.");
            }

            var dbStoreItem = Mapper.Map<UpdateStoreItemRequest, DbStoreItem>(createRequest);
            dbStoreItem.CreatedDate = DateTime.UtcNow;
            _storeItemContext.Items.Add(dbStoreItem);

            await _storeItemContext.SaveChangesAsync();

            return Mapper.Map<StoreItem>(dbStoreItem);
        }

        public async Task<StoreItem> UpdateStoreItemAsync(int storeItemId, UpdateStoreItemRequest updateRequest)
        {
            var dbProduct = _productContext.Products.Where(p => p.Id == updateRequest.ProductId).FirstOrDefault();
            if (dbProduct == null)
            {
                throw new RequestedResourceHasConflictException("Product");
            }

            var dbAllowedSectionCatagegories = _categoryContext.Categories.Where(c => c.StoreHiveSectionId == updateRequest.HiveSectionId && c.ProductCategoryId == dbProduct.Category.Id).FirstOrDefault();
            if (dbAllowedSectionCatagegories == null)
            {
                throw new RequestedResourceHasConflictException("Unallowable product category for this hive section.");
            }

            var dbStoreItems = await _storeItemContext.Items.Where(i => i.Id == storeItemId).ToArrayAsync();
            if (dbStoreItems.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbStoreItem = dbStoreItems[0];

            if (dbStoreItem.IsApproved != updateRequest.IsApproved)
            {
                dbStoreItem.ConfirmationDate = DateTime.UtcNow;
            }

            Mapper.Map(updateRequest, dbStoreItem);

            await _storeItemContext.SaveChangesAsync();

            return Mapper.Map<StoreItem>(dbStoreItem);
        }

        /// <inheritdoc/>
        public async Task SetStatusAsync(int storeItemId, bool deletedStatus)
        {
            var dbStoreItems = await _storeItemContext.Items.Where(i => storeItemId == i.Id).ToArrayAsync();

            if (dbStoreItems.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbStoreItem = dbStoreItems[0];
            if (dbStoreItem.IsDeleted != deletedStatus)
            {
                dbStoreItem.IsDeleted = deletedStatus;
                dbStoreItem.DeletionDate = DateTime.UtcNow;
                await _storeItemContext.SaveChangesAsync();
            }
        }
    }
}
