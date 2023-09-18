using Microsoft.AspNetCore.Mvc;
using SellSphere.Repository.Dto.Condition;
using SellSphere.Repository.Dto.DeliveryDto;
using SellSphere.Repository.Repositories;

namespace SellSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController
    {
        private readonly ILogger<DeliveryController> _logger;
        private readonly DeliveryRepository _deliveryRepository;
        public DeliveryController(ILogger<DeliveryController> logger, DeliveryRepository deliveryRepository)
        {
            _logger = logger;
            _deliveryRepository = deliveryRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<DeliveryReadDto>> GetListAsync()
        {
            return await _deliveryRepository.GetDeliveriesAsync();
        }
    }
}
