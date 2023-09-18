using Microsoft.AspNetCore.Mvc;
using SellSphere.Core;
using SellSphere.Repository.Dto.ActivityDto;
using SellSphere.Repository.Repositories;

namespace SellSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : Controller
    {
        private readonly ILogger<ActivityController> _logger;
        private readonly ActivityRepository _activityRepository;
        public ActivityController(ILogger<ActivityController> logger, ActivityRepository activityRepository)
        {
            _logger = logger;
            _activityRepository = activityRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<ActivityReadDto>> GetListAsync()
        {
            return await _activityRepository.GetActivitiesAsync();
        }

       
        /*[HttpPost("{id}")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(ActivityCreateDto activityDto)
        {
            if (ModelState.IsValid)
            {
                var activity = await _activityRepository.AddActivityAsync(new Activity
                {
                    ActivityName = activityDto.ActivityName
                });
                return RedirectToAction("Index", "Activity", new { id = activity.ActivityId });
            }
            return View(activityDto);
        }*/
    }
}
