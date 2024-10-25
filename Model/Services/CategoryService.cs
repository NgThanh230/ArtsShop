using ArtsShop.Data;
using ArtsShop.Model.Product;
using Azure;
using Microsoft.EntityFrameworkCore;
using System;

namespace ArtsShop.Model.Services
{
    public class CategoryService
    {
        private readonly ArtShopDbContext _context; // Inject your DbContext

        public CategoryService(ArtShopDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<Category>> Create(Category category)
        {
            // Check for existing category
            var existingCategory = await _context.Categories
                .FirstOrDefaultAsync(c => c.Name == category.Name || c.Key == category.Key);

            if (existingCategory != null)
            {
                return new ApiResponse<Category>(false, 100, "The category already exists", null);
            }

            // Add the new category
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return new ApiResponse<Category>(true, null, "Category created successfully", category);
        }
        public async Task<ApiResponse<Category>> Update(int id, Category category)
        {
            // Find the existing category by ID
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                return new ApiResponse<Category>(false, 100, "Category not found", null);
            }

            // Update the category properties
            existingCategory.Name = category.Name;
            existingCategory.Key = category.Key;
            existingCategory.Type = category.Type;
            existingCategory.IsAvailable = category.IsAvailable;

            // Save changes
            await _context.SaveChangesAsync();

            return new ApiResponse<Category>(true, null, "Category updated successfully", existingCategory);
        }
        public async Task<ApiResponse<Category>> GetById(int id)
        {
            // Find the category by ID
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return new ApiResponse<Category>(false, 100, "Category not found", null);
            }

            return new ApiResponse<Category>(true, null, "", category);
        }
        public async Task<ApiResponse<Category>> GetAll()
        {
            // Retrieve all categories
            var categories = await _context.Categories.ToListAsync();
            return new ApiResponse<Category>(true, null, "", categories);
        }
        public async Task<ApiResponse<Category>> GetByType(string type)
        {
            // Find categories by type
            var categories = await _context.Categories
                .Where(c => c.Type == type)
                .ToListAsync();

            return new ApiResponse<Category>(true, null, "", categories);
        }

    }
}