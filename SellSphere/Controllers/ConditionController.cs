using Microsoft.AspNetCore.Mvc;
using SellSphere.Repository.Dto.CategoryDto;
using SellSphere.Repository.Dto.Condition;
using SellSphere.Repository.Repositories;

namespace SellSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConditionController
    {
        private readonly ILogger<ConditionController> _logger;
        private readonly ConditionRepository _conditionRepository;
        public ConditionController(ILogger<ConditionController> logger, ConditionRepository conditionRepository)
        {
            _logger = logger;
            _conditionRepository = conditionRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<ConditionReadDto>> GetListAsync()
        {
            return await _conditionRepository.GetConditionsAsync();
        }
    }
}
