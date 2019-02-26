﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a product category service.
    /// </summary>
    public interface IProductCategoryService
    {
        /// <summary>
        /// Gets a list of products categories.
        /// </summary>
        /// <param name="start">A start.</param>
        /// <param name="amount">An amount.</param>
        /// <returns>A <see cref="Task{List{ProductCategoryListItem}}"/>.</returns>
        Task<List<ProductCategoryListItem>> GetCategoriesAsync(int start, int amount);

        /// <summary>
        /// Gets a product category with specified identifier.
        /// </summary>
        /// <param name="categoryId">A product category identifier.</param>
        /// <returns>A <see cref="Task{ProductCategory}"/>.</returns>
        Task<ProductCategory> GetCategoryAsync(int categoryId);

        /// <summary>
        /// Gets a list of allowed product categories for specified hive section.
        /// </summary>
        /// <param name="hiveSectionId">A hive section identifier.</param>
        /// <returns>A <see cref="Task{List{ProductCategory}}"/>.</returns>
        Task<List<ProductCategory>> GetAllowedHiveSectionProductCategoriesAsync(int hiveSectionId);

        /// <summary>
        /// Creates a new product category.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateProductCategoryRequest"/>.</param>
        /// <returns>A <see cref="Task{ProductCategory}"/>.</returns>
        Task<ProductCategory> CreateCategoryAsync(UpdateProductCategoryRequest createRequest);

        /// <summary>
        /// Updates an existed product category.
        /// </summary>
        /// <param name="categoryId">A product category identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateProductCategoryRequest"/>.</param>
        /// <returns>A <see cref="Task{ProductCategory}"/>.</returns>
        Task<ProductCategory> UpdateCategoryAsync(int categoryId, UpdateProductCategoryRequest updateRequest);

        /// <summary>
        /// Deletes an existed product category.
        /// </summary>
        /// <param name="categoryId">A product category identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteCategoryAsync(int categoryId);

        /// <summary>
        /// Sets deleted status for a product category.
        /// </summary>
        /// <param name="categoryId">A product category identifier.</param>
        /// <param name="deletedStatus">Status.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task SetStatusAsync(int categoryId, bool deletedStatus);
    }
}
