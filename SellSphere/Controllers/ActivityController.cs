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
        private readonly SellSphereContext dbContext;
        private readonly ActivityRepository _activityRepository;
        public ActivityController(ActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public IActionResult Index()
        {
            var activities = _activityRepository.GetActivities();
            return View(activities);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                var createdActivity = await _activityRepository.AddActivityAsync(activity);
                return RedirectToAction("Edit", "Activity", new { id = createdActivity.ActivityId });
            }
            return View(activity);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_activityRepository.GetActivity(id));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Activity activity)
        {
            if (ModelState.IsValid)
            {
                await _activityRepository.UpdateActivityAsync(activity);
                return RedirectToAction("Index");
            }
            return View(activity);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_activityRepository.GetActivity(id));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(Activity activity)
        {
            await _activityRepository.DeleteActivityAsync(activity.ActivityId);
            return RedirectToAction("Index");
        }
    }
}
