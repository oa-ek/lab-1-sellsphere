using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using SellSphere.Core;
using SellSphere.Models;
using SellSphere.Repository.Dto.GoodsDto;
using SellSphere.Repository.Repositories;

namespace SellSphere.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class GoodsController : Controller
    {
        private readonly ILogger<GoodsController> _logger;

        private readonly GoodsRepository _goodRepository;
        /*private readonly ActivityRepository _activityRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly ConditionRepository _conditionRepository;
        private readonly ContactsRepository _contactsRepository;
        private readonly DeliveryRepository _deliveryRepository;
        private readonly LocationRepository _locationRepository;
        private readonly UsersRepository _usersRepository;*/

        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;

        public GoodsController(ILogger<GoodsController> logger, GoodsRepository goodRepository/*,
            ActivityRepository activityRepository, CategoryRepository categoryRepository, ConditionRepository conditionRepository,
            ContactsRepository contactRepository, DeliveryRepository deliveryRepository,
            LocationRepository locationRepository, UsersRepository usersRepository, UserManager<User> userManager, SignInManager<User> signInManager*/)
        {
            _logger = logger;
            _goodRepository = goodRepository;
            /*_activityRepository = activityRepository;
            _categoryRepository = categoryRepository;
            _conditionRepository = conditionRepository;
            _contactsRepository = contactRepository;
            _deliveryRepository = deliveryRepository;
            _locationRepository = locationRepository;
            _usersRepository = usersRepository;
            _userManager = userManager;
            _signInManager = signInManager;*/
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_goodRepository.GetGoodes());
        }

        [HttpGet]
        public GoodsRepository GetGoodsRepository()
        {
            return _goodRepository;
        }

        [HttpPost("post")]
        public async Task<int> AddGood(GoodsCreateDto dto)
        {
            return await _goodRepository.AddGood(dto);
        }

        /// <summary>
        /// Update book
        /// </summary>
        /// <param name="id"></param>

        [HttpGet("Get-good")]
        public async Task<IEnumerable<GoodsReadDto>> GetListAsync()
        {
            return await _goodRepository.GetGoodsAsync();
        }


        /// <summary>
        /// Delete book by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _goodRepository.DeleteGood(id);
        }
        /*[HttpGet]
        public ActionResult Details(int id)
        {
            ViewBag.Models = _categoryRepository.GetCategory(id);
            return View(_categoryRepository.GetCategory(id));
        }*/

        /*[HttpGet]
        public IActionResult Sellgood()
        {
            ViewBag.Activities = _activityRepository.GetActivityTypes();
            ViewBag.Categories = _categoryRepository.GetCategoryTypes();
            ViewBag.Conditions = _conditionRepository.GetConditionTypes();
            ViewBag.Contacts = _contactsRepository.GetContactsTypes();
            ViewBag.Delivery = _deliveryRepository.GetDeliveryTypes();
            ViewBag.Location = _locationRepository.GetLocationTypes();
            return View();
        }*/

        /*[HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Sellgood(GoodsCreateDto goodDto, string activityName, string categoryName,
            string conditionName, string contactsName, string deliveryName, string locationName)
        {
            ViewBag.Activities = _activityRepository.GetActivityTypes();
            ViewBag.Categories = _categoryRepository.GetCategoryTypes();
            ViewBag.Conditions = _conditionRepository.GetConditionTypes();
            ViewBag.Contacts = _contactsRepository.GetContactsTypes();
            ViewBag.Delivery = _deliveryRepository.GetDeliveryTypes();
            ViewBag.Location = _locationRepository.GetLocationTypes();
            if (ModelState.IsValid)
            {
                var activity = _activityRepository.GetActivityByName(activityName);
                if (activity == null)
                {
                    activity = new Activity() { ActivityName = activityName };
                    activity = await _activityRepository.AddActivityAsync(activity);
                }

                var category = _categoryRepository.GetCategoryByName(categoryName);
                if (category == null)
                {
                    category = new Category() { CategoryName = categoryName };
                    category = await _categoryRepository.AddCategoryAsync(category);
                }

                var condition = _conditionRepository.GetConditionByName(conditionName);
                if (condition == null)
                {
                    condition = new Condition() { ConditionName = conditionName };
                    condition = await _conditionRepository.AddConditionAsync(condition);
                }

                var contacts = _contactsRepository.GetContactsByName(contactsName);
                if (contacts == null)
                {
                    contacts = new Contacts() { ContactPerson = contactsName };
                    contacts = await _contactsRepository.AddContactsAsync(contacts);
                }

                var delivery = _deliveryRepository.GetDeliveryByName(deliveryName);
                if (delivery == null)
                {
                    delivery = new Delivery() { DeliveryName = deliveryName };
                    delivery = await _deliveryRepository.AddDeliveryAsync(delivery);
                }


                var location = _locationRepository.GetLocationByName(locationName);
                if (location == null)
                {
                    location = new Location() { LocationName = locationName };
                    location = await _locationRepository.AddLocationAsync(location);
                }

                var user = _usersRepository.GetUserByEmail(User.Identity.Name);
                if (user == null)
                {
                    user = new User() { Email = User.Identity.Name };
                }

                var good = await _goodRepository.AddGoodsAsync(new Goods
                {
                    Activity = activity,
                    Category = category,
                    Condition = condition,
                    Contacts = contacts,
                    Price = goodDto.Price,
                    PublicationDate = goodDto.PublicationDate,
                    Delivery = delivery,
                    Location = location,
                    User = user
                });
                return RedirectToAction("Index", "Home", new { id = good.GoodsId });
            }
            return View(goodDto);
        }*/

        /*[HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Activities = _activityRepository.GetActivityTypes();
            ViewBag.Categories = _categoryRepository.GetCategoryTypes();
            ViewBag.Conditions = _conditionRepository.GetConditionTypes();
            ViewBag.Contacts = _contactsRepository.GetContactsTypes();
            ViewBag.Delivery = _deliveryRepository.GetDeliveryTypes();
            ViewBag.Location = _locationRepository.GetLocationTypes();
            return View(await _goodRepository.GetGoodsDto(id));
        }*/

        /*[HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(GoodsReadDto goodDto, string activityName, string categoryName,
            string conditionName, string contactsName, string deliveryName, string locationName)
        {
            if (ModelState.IsValid)
            {
                await _goodRepository.UpdateAsync(goodDto, activityName, categoryName, conditionName, contactsName, deliveryName, locationName);
                return RedirectToAction("Details", "Goods", new { id = goodDto.Id });
            }
            ViewBag.Activities = _activityRepository.GetActivityTypes();
            ViewBag.Categories = _categoryRepository.GetCategoryTypes();
            ViewBag.Conditions = _conditionRepository.GetConditionTypes();
            ViewBag.Contacts = _contactsRepository.GetContactsTypes();
            ViewBag.Delivery = _deliveryRepository.GetDeliveryTypes();
            ViewBag.Location = _locationRepository.GetLocationTypes();
            return View(goodDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _goodRepository.GetGoodsDto(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _goodRepository.DeleteGoodsAsync(id);
            return RedirectToAction("Index", "Home");
        }

      
    }*/
    }
}