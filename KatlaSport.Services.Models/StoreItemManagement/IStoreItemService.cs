using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.StoreItemManagement
{
    public interface IStoreItemService
    {
        /// <summary>
        /// Gets a store item with specified identifier.
        /// </summary>
        /// <param name="storeItemId">A store item identifier.</param>
        /// <returns>A <see cref="Task{StoreItem}"/>.</returns>
        Task<StoreItem> GetStoreItemAsync(int storeItemId);

        /// <summary>
        /// Gets a list of a hive section store items.
        /// </summary>
        /// <param name="hiveSectionId">A hive section identifier.</param>
        /// <returns>A <see cref="Task{List{StoreItem}}"/>.</returns>
        Task<List<StoreItem>> GetHiveSectionStoreItemsAsync(int hiveSectionId);

        /// <summary>
        /// Creates a new hive section store item.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateHiveSectionRequest"/>.</param>
        /// <returns>A <see cref="Task{Hive}"/>.</returns>
        Task<StoreItem> CreateStoreItemAsync(UpdateStoreItemRequest createRequest);
    }
}
