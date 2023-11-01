using Microsoft.AspNetCore.Mvc;
using SellSphere.Core;
using SellSphere.Repository.Dto.CategoryDto;
using SellSphere.Repository.Dto.Condition;
using SellSphere.Repository.Repositories;

namespace SellSphere.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ConditionController : Controller
    {
        private readonly ILogger<ConditionController> _logger;
        private readonly SellSphereContext dbContext;
        private readonly ConditionRepository _conditionRepository;
        public ConditionController(ConditionRepository conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        public IActionResult Index()
        {
            var conditions = _conditionRepository.GetConditions();
            return View(conditions);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Condition condition)
        {
            if (ModelState.IsValid)
            {
                var createdCondition = await _conditionRepository.AddConditionAsync(condition);
                return RedirectToAction("Edit", "Condition", new { id = createdCondition.ConditionId });
            }
            return View(condition);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_conditionRepository.GetCondition(id));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Condition condition)
        {
            if (ModelState.IsValid)
            {
                await _conditionRepository.UpdateConditionAsync(condition);
                return RedirectToAction("Index");
            }
            return View(condition);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_conditionRepository.GetCondition(id));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(Condition condition)
        {
            await _conditionRepository.DeleteConditionAsync(condition.ConditionId);
            return RedirectToAction("Index");
        }
    }
}
