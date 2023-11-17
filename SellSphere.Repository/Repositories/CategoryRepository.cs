using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SellSphere.Core;
using SellSphere.Repository.Dto.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellSphere.Repository.Repositories
{
    public class CategoryRepository
    {
        
            private readonly SellSphereContext _ctx;

            public CategoryRepository(SellSphereContext _ctx)
            {
                this._ctx = _ctx;
            }

            public async Task<Category> AddCategoryAsync(Category category)
            {
                _ctx.Categories.Add(category);
                await _ctx.SaveChangesAsync();
                return _ctx.Categories.FirstOrDefault(x => x.CategoryName == category.CategoryName);
            }

            public Category GetCategory(int id)
            {
                return _ctx.Categories.FirstOrDefault(x => x.CategoryId == id);
            }
            public Category GetCategoryByName(string name)
            {
                return _ctx.Categories.FirstOrDefault(x => x.CategoryName == name);
            }

            public List<Category> GetCategories()
            {
                var categoryList = _ctx.Categories.ToList();
                return categoryList;
            }

            public async Task DeleteCategoryAsync(int id)
            {
                _ctx.Remove(GetCategory(id));
                await _ctx.SaveChangesAsync();
            }

            public async Task UpdateCategoryAsync(Category updatedCategory)
            {
                var category = _ctx.Categories.FirstOrDefault(x => x.CategoryId == updatedCategory.CategoryId);

               category.CategoryName = updatedCategory.CategoryName;
                await _ctx.SaveChangesAsync();
            }
        }
    
}

