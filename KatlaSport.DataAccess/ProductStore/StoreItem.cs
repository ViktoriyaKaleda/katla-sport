using System;
using KatlaSport.DataAccess.ProductCatalogue;
using KatlaSport.DataAccess.ProductStoreHive;

namespace KatlaSport.DataAccess.ProductStore
{
    /// <summary>
    /// Represents a product store item.
    /// </summary>
    public class StoreItem
    {
        /// <summary>
        /// Gets or sets a product store item ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a product ID.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets a product.
        /// </summary>
        public virtual CatalogueProduct Product { get; set; }

        /// <summary>
        /// Gets or sets a location ID.
        /// </summary>
        public int HiveSectionId { get; set; }

        /// <summary>
        /// Gets or sets a location.
        /// </summary>
        public virtual StoreHiveSection HiveSection { get; set; }

        /// <summary>
        /// Gets or sets a quantity of items of certain product in the location.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a store item is approved.
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets a timestamp when the store item was added.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets a timestamp when the store item was confirmed.
        /// </summary>
        public DateTime? ConfirmationDate { get; set; }
    }
}
