using Microsoft.AspNetCore.Mvc;
using SellSphere.Repository.Dto.Condition;
using SellSphere.Repository.Dto.ContactsDto;
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

        /// <summary>
        /// Create author
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost]
        public async Task<int> AddDelivery(DeliveryCreateDto dto)
        {
            return await _deliveryRepository.AddDelivery(dto);
        }

        /// <summary>
        /// Update author
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public async Task<int> EditDelivery(DeliveryReadDto delivery)
        {
            return await _deliveryRepository.UpdateDelivery(delivery);
        }

        /// <summary>
        /// Delete author by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _deliveryRepository.DeleteDelivery(id);
        }
    }
}
