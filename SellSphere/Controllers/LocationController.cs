using Microsoft.AspNetCore.Mvc;
using SellSphere.Repository.Dto.Condition;
using SellSphere.Repository.Dto.LocationDto;
using SellSphere.Repository.Repositories;

namespace SellSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController
    {
        private readonly ILogger<LocationController> _logger;
        private readonly LocationRepository _locationRepository;
        public LocationController(ILogger<LocationController> logger, LocationRepository locationRepository)
        {
            _logger = logger;
            _locationRepository = locationRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<LocationReadDto>> GetListAsync()
        {
            return await _locationRepository.GetLocationsAsync();
        }
    }
}
