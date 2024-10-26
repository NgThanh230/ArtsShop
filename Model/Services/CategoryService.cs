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

        public async Task<Response<Category>> Create(Category category)
        {
            // Check for existing category
            var existingCategory = await _context.Categories
                .FirstOrDefaultAsync(c => c.Name == category.Name || c.Key == category.Key);

            if (existingCategory != null)
            {
                return new Response<Category>(false, "The category already exists", null);
            }

            // Add the new category
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return new Response<Category>(true, "Category created successfully", category);
        }
        public async Task<Response<Category>> Update(int id, Category category)
        {
            // Find the existing category by ID
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                return new Response<Category>(false, "Category not found", null);
            }

            // Update the category properties
            existingCategory.Name = category.Name;
            existingCategory.Key = category.Key;
            existingCategory.Type = category.Type;
            existingCategory.IsAvailable = category.IsAvailable;

            // Save changes
            await _context.SaveChangesAsync();

            return new Response<Category>(true, "Category updated successfully", existingCategory);
        }
        public async Task<Response<Category>> GetById(int id)
        {
            // Find the category by ID
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return new Response<Category>(false, "Category not found", null);
            }

            return new Response<Category>(true, "", category);
        }
        public async Task<Response<List<Category>>> GetAll()
        {
            // Retrieve all categories
            var categories = await _context.Categories.ToListAsync();
            return new Response<List<Category>>(true,  "", categories);
        }
        public async Task<Response<List<Category>>> GetByType(string type)
        {
            // Find categories by type
            var categories = await _context.Categories
                .Where(c => c.Type == type)
                .ToListAsync();

            return new Response<List<Category>>(true,  "", categories);
        }

    }
}