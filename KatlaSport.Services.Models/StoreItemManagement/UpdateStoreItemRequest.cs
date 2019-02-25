namespace KatlaSport.Services.StoreItemManagement
{
    public class UpdateStoreItemRequest
    {
        /// <summary>
        /// Gets or sets a product identifier.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets a hive section identifier.
        /// </summary>
        public int HiveSectionId { get; set; }

        /// <summary>
        /// Gets or sets a sstore item quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}
