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
        private readonly SellSphereDbContext _ctx;
        private readonly IMapper _mapper;
        public CategoryRepository(SellSphereDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryReadDto>> GetCategoriesAsync()
        {
            return _mapper.Map<IEnumerable<CategoryReadDto>>(await _ctx.Categories.ToListAsync());
        }
        public async Task<Category> AddCategoryAsync(Category model)
        {
            _ctx.Categories.Add(model);
            await _ctx.SaveChangesAsync();
            return _ctx.Categories.FirstOrDefault(x => x.CategoryName == model.CategoryName);
        }

        public List<Category> GetCategoryTypes()
        {
            var categoryList = _ctx.Categories.ToList();
            return categoryList;
        }

        public Category GetCategory(int id)
        {
            return _ctx.Categories.FirstOrDefault(x => x.CategoryId == id);
        }

        public Category GetCategoryByName(string name)
        {
            return _ctx.Categories.FirstOrDefault(x => x.CategoryName == name);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            _ctx.Remove(GetCategory(id));
            await _ctx.SaveChangesAsync();
        }
    }
}

