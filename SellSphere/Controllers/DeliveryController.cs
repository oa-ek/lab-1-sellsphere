using Microsoft.AspNetCore.Mvc;
using SellSphere.Core;
using SellSphere.Repository.Dto.Condition;
using SellSphere.Repository.Dto.DeliveryDto;
using SellSphere.Repository.Repositories;

namespace SellSphere.Controllers
{
   // [Route("api/[controller]")]
    //[ApiController]
    public class DeliveryController : Controller
    {
        private readonly ILogger<DeliveryController> _logger;
        private readonly SellSphereContext dbContext;
        private readonly DeliveryRepository _deliveryRepository;
        public DeliveryController(DeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public IActionResult Index()
        {
            var delivery = _deliveryRepository.GetDeliveries();
            return View(delivery);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                var createdDelivery = await _deliveryRepository.AddDeliveryAsync(delivery);
                return RedirectToAction("Edit", "Delivery", new { id = createdDelivery.DeliveryId });
            }
            return View(delivery);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_deliveryRepository.GetDelivery(id));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                await _deliveryRepository.UpdateDeliveryAsync(delivery);
                return RedirectToAction("Index");
            }
            return View(delivery);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_deliveryRepository.GetDelivery(id));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(Delivery delivery)
        {
            await _deliveryRepository.DeleteDeliveryAsync(delivery.DeliveryId);
            return RedirectToAction("Index");
        }
    }
}
