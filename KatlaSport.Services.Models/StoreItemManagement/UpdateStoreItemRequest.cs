using FluentValidation.Attributes;

namespace KatlaSport.Services.StoreItemManagement
{
    /// <summary>
    /// Represents a request for creating and updating a hive section store item.
    /// </summary>
    [Validator(typeof(UpdateStoreItemRequestValidator))]
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
        /// Gets or sets a store item quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a store item is approved.
        /// </summary>
        public int IsApproved { get; set; }
    }
}
