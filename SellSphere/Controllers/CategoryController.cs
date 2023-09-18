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
    }
}
