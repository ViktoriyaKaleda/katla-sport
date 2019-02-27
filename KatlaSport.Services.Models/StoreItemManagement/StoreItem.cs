using System;

namespace KatlaSport.Services.StoreItemManagement
{
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
        /// Gets or sets a product name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets a product code.
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// Gets or sets a parent product category code.
        /// </summary>
        public string ProductCategoryCode { get; set; }

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

        /// <summary>
        /// Gets or sets a timestamp when the store item was deleted.
        /// </summary>
        public DateTime? DeletionDate { get; set; }
    }
}
