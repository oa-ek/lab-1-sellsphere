using Microsoft.AspNetCore.Mvc;
using SellSphere.Core;

using SellSphere.Repository.Dto.LocationDto;
using SellSphere.Repository.Repositories;

namespace SellSphere.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class LocationController : Controller
    {
        private readonly ILogger<LocationController> _logger;
        private readonly SellSphereContext dbContext;
        private readonly LocationRepository _locationRepository;
        public LocationController(LocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public IActionResult Index()
        {
            var locations = _locationRepository.GetLocations();
            return View(locations);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Location location)
        {
            if (ModelState.IsValid)
            {
                var createdLocation = await _locationRepository.AddLocationAsync(location);
                return RedirectToAction("Edit", "Location", new { id = createdLocation.LocationId });
            }
            return View(location);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_locationRepository.GetLocation(id));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                await _locationRepository.UpdateLocationAsync(location);
                return RedirectToAction("Index");
            }
            return View(location);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_locationRepository.GetLocation(id));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(Location location)
        {
            await _locationRepository.DeleteLocationAsync(location.LocationId);
            return RedirectToAction("Index");
        }
    }
}
