using Microsoft.AspNetCore.Mvc;
using SellSphere.Repository.Dto.Condition;
using SellSphere.Repository.Dto.DeliveryDto;
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

        /// <summary>
        /// Create author
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost]
        public async Task<int> AddLocation(LocationCreateDto dto)
        {
            return await _locationRepository.AddLocation(dto);
        }

        /// <summary>
        /// Update author
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public async Task<int> EditLocation(LocationReadDto location)
        {
            return await _locationRepository.UpdateLocation(location);
        }

        /// <summary>
        /// Delete author by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _locationRepository.DeleteLocation(id);
        }

    }
}
