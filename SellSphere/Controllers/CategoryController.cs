using Microsoft.AspNetCore.Mvc;
using SellSphere.Repository.Dto.CategoryDto;
using SellSphere.Repository.Repositories;

namespace SellSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly CategoryRepository _categoryRepository;
        public CategoryController(ILogger<CategoryController> logger, CategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<CategoryReadDto>> GetListAsync()
        {
            return await _categoryRepository.GetCategoriesAsync();
        }

        /// <summary>
        /// Create author
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost]
        public async Task<int> AddCategory(CategoryCreateDto dto)
        {
            return await _categoryRepository.AddCategory(dto);
        }

        /// <summary>
        /// Update author
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public async Task<int> EditActor(CategoryReadDto category)
        {
            return await _categoryRepository.UpdateCategory(category);
        }

        /// <summary>
        /// Delete author by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _categoryRepository.DeleteCategory(id);
        }
    }
}
