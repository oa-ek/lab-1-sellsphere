using Microsoft.AspNetCore.Mvc;
using SellSphere.Core;
using SellSphere.Models;
using System.Diagnostics;
using SellSphere.Repository.Repositories;
using Microsoft.AspNetCore.Hosting;
using SellSphere.Repository.Dto.GoodsDto;

namespace SellSphere.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SellSphereContext _ctx;
        private readonly CategoryRepository categoriesRepositories;
        private readonly LocationRepository locationsRepositories;
        private readonly ActivityRepository activitiesRepositories;
        private readonly ConditionRepository conditionsRepositories;
        private readonly DeliveryRepository deliveriesRepositories;
        private readonly GoodsRepository goodsRepositories;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, SellSphereContext ctx, CategoryRepository categoriesRepositories, GoodsRepository goodsRepository, LocationRepository locationsRepository, ActivityRepository activitiesRepositories, ConditionRepository conditionsRepositories, DeliveryRepository deliveriesRepositories, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _ctx = ctx;
            this.categoriesRepositories = categoriesRepositories;
            this.goodsRepositories = goodsRepository;
            this.locationsRepositories = locationsRepository;
            this.activitiesRepositories = activitiesRepositories;
            this.conditionsRepositories = conditionsRepositories;
            this.deliveriesRepositories = deliveriesRepositories;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult Index()
        {
            return View(goodsRepositories.GetGoods());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = categoriesRepositories.GetCategories();
            ViewBag.Activities = activitiesRepositories.GetActivities();
            ViewBag.Conditions = conditionsRepositories.GetConditions();
            ViewBag.Deliveries = deliveriesRepositories.GetDeliveries();
            ViewBag.Locations = locationsRepositories.GetLocations();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(GoodsCreateDto goodCreateDto, string categories, string activities, string conditionses, string contactses, string deliveries, string locations, IFormFile picture)
        {
            ViewBag.Categories = categoriesRepositories.GetCategories();
            ViewBag.Activities = activitiesRepositories.GetActivities();
            ViewBag.Conditions = conditionsRepositories.GetConditions();
            ViewBag.Deliveries = deliveriesRepositories.GetDeliveries();
            ViewBag.Locations = locationsRepositories.GetLocations();
            if (ModelState.IsValid)
            {
                //string picturePath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "goods", picture.FileName);

                //using (FileStream stream = new FileStream(picturePath, FileMode.Create))
                   // picture.CopyTo(stream);

               // goodCreateDto.ImgPath = Path.Combine("img", "keys", picture.FileName);



                var category = categoriesRepositories.GetCategoryByName(categories);
                if (category == null)
                {
                    category = new Category() { CategoryName = categories };
                    category = await categoriesRepositories.AddCategoryAsync(category);
                }

                var activity = activitiesRepositories.GetActivityByName(activities);
                if (activity == null)
                {
                    activity = new Core.Activity() { ActivityName = activities };
                    activity = await activitiesRepositories.AddActivityAsync(activity);
                }

                var condition = conditionsRepositories.GetConditionByName(conditionses);
                if (condition == null)
                {
                    condition = new Condition() { ConditionName = conditionses };
                    condition= await conditionsRepositories.AddConditionAsync(condition);
                }

             
                var delivery = deliveriesRepositories.GetDeliveryByName(deliveries);
                if (delivery == null)
                {
                    delivery = new Delivery() { DeliveryName = deliveries };
                    delivery = await deliveriesRepositories.AddDeliveryAsync(delivery);
                }

                var location = locationsRepositories.GetLocationByName(locations);
                if (location == null)
                {
                    location = new Location() { LocationName = locations };
                    location = await locationsRepositories.AddLocationAsync(location);
                }
                var good = await goodsRepositories.AddGoodAsync(new Goods()
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

                return RedirectToAction("Index", "Home", new { id = good.GoodsId });
            }
            return View(goodCreateDto);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        private void GetViewBags()
        {
            ViewBag.Categories = categoriesRepositories.GetCategories();
            

        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}

