using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductStore;

namespace KatlaSport.Services.StoreItemManagement
{
    public class StoreItemService : IStoreItemService
    {
        private readonly IProductStoreContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreItemService"/> class with specified <see cref="IProductStoreContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IProductStoreContext"/>.</param>
        public StoreItemService(IProductStoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<List<StoreItem>> GetHiveSectionStoreItemsAsync(int hiveSectionId)
        {
            var dbHiveSections = await _context.Items.Where(i => i.HiveSectionId == hiveSectionId && i.Quantity > 0).OrderBy(i => i.Id).ToArrayAsync();
            var hiveSections = dbHiveSections.Select(i => Mapper.Map<StoreItem>(i)).ToList();
            return hiveSections;
        }

        /// <inheritdoc/>
        public Task<StoreItem> CreateHiveSectionStoreItemAsync(UpdateStoreItemRequest createRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}
