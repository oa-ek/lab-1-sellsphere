using Microsoft.AspNetCore.Mvc;
using SellSphere.Core;
using SellSphere.Repository.Dto.ActivityDto;
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

        /// <summary>
        /// Create author
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost]
        public async Task<int> AddCondition(ConditionCreateDto dto)
        {
            return await _conditionRepository.AddCondition(dto);
        }

        /// <summary>
        /// Update author
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public async Task<int> EditCondition(ConditionReadDto condition)
        {
            return await _conditionRepository.UpdateCondition(condition);
        }

        /// <summary>
        /// Delete author by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _conditionRepository.DeleteCondition(id);
        }
    }
}
