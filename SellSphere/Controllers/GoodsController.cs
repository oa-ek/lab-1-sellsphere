using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic.FileIO;
using SellSphere.Core;
using SellSphere.Models;
using SellSphere.Repository.Dto.GoodsDto;
using SellSphere.Repository.Repositories;
using System.Drawing.Drawing2D;

namespace SellSphere.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class GoodsController : Controller
    {
        private readonly ILogger<GoodsController> _logger;

        private readonly GoodsRepository goodsRepository;
        private readonly ActivityRepository activitiesRepository;
        private readonly CategoryRepository categoriesRepository;
        private readonly ConditionRepository conditionsRepository;
        //private readonly ContactsRepository contactsRepository;
        private readonly DeliveryRepository deliveriesRepository;
        private readonly LocationRepository locationsRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UsersRepository usersRepository;

      

        public GoodsController(ILogger<GoodsController> logger, GoodsRepository goodsRepository, ActivityRepository activitiesRepository, CategoryRepository categoriesRepository,
            ConditionRepository conditionsRepository, DeliveryRepository deliveriesRepository,
            LocationRepository locationsRepository, UsersRepository usersRepository, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            this.goodsRepository = goodsRepository;
            this.activitiesRepository = activitiesRepository;
            this.categoriesRepository = categoriesRepository;
            this.conditionsRepository = conditionsRepository;
            
            this.deliveriesRepository = deliveriesRepository;
            this.locationsRepository = locationsRepository;
            this.usersRepository = usersRepository;
            _webHostEnvironment = webHostEnvironment;
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(goodsRepository.GetGoods());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = categoriesRepository.GetCategories();
            ViewBag.Activities = activitiesRepository.GetActivities();
            ViewBag.Conditions = conditionsRepository.GetConditions();
          
            ViewBag.Deliveries = deliveriesRepository.GetDeliveries();
            ViewBag.Locations = locationsRepository.GetLocations();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(GoodsCreateDto goodCreateDto, string categories, string activities, string conditions, string contactses, string deliveries, string locations, IFormFile picture)
        {
            ViewBag.Categories = categoriesRepository.GetCategories();
            ViewBag.Activities = activitiesRepository.GetActivities();
            ViewBag.Conditions = conditionsRepository.GetConditions();
           
            ViewBag.Deliveries = deliveriesRepository.GetDeliveries();
            ViewBag.Locations = locationsRepository.GetLocations();
            if (ModelState.IsValid)
            {
                string picturePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "goods", picture.FileName);

                using (FileStream stream = new FileStream(picturePath, FileMode.Create))
                    picture.CopyTo(stream);

                goodCreateDto.ImgPath = Path.Combine("img", "keys", picture.FileName);



                var category = categoriesRepository.GetCategoryByName(categories);
                if (category == null)
                {
                    category = new Category() { CategoryName = categories };
                    category = await categoriesRepository.AddCategoryAsync(category);
                }

                var activity = activitiesRepository.GetActivityByName(activities);
                if (activity == null)
                {
                    activity = new Activity() { ActivityName = activities };
                    activity = await activitiesRepository.AddActivityAsync(activity);
                }

                var condition = conditionsRepository.GetConditionByName(conditions);
                if (condition == null)
                {
                    condition = new Condition() { ConditionName = conditions };
                    condition = await conditionsRepository.AddConditionAsync(condition);
                }

              

                var delivery = deliveriesRepository.GetDeliveryByName(deliveries);
                if (delivery == null)
                {
                    delivery = new Delivery() { DeliveryName = deliveries };
                    delivery = await deliveriesRepository.AddDeliveryAsync(delivery);
                }

                var location = locationsRepository.GetLocationByName(locations);
                if (location == null)
                {
                    location = new Location() { LocationName = locations };
                    location = await locationsRepository.AddLocationAsync(location);
                }
                var good = await goodsRepository.AddGoodAsync(new Goods()
                {
                    GoodsName = goodCreateDto.GoodsName,
                    Description = goodCreateDto.Description,
                    Price = goodCreateDto.Price,
                    ImgPath = goodCreateDto.ImgPath,
                    Category = category,
                    Activity = activity,
                    Condition = condition,
                    Delivery = delivery,
                    Location = location
                });

                return RedirectToAction("Edit", "Home", new { id = good.GoodsId });
            }
            return View(goodCreateDto);
        }


    }
}