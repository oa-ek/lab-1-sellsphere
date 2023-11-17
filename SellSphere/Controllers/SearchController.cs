using Microsoft.AspNetCore.Mvc;
using SellSphere.Repository.Repositories;

namespace SellSphere.Controllers
{
    public class SearchController : Controller
    {
        private readonly GoodsRepository goodsRepository;

        public SearchController(GoodsRepository goodsRepository)
        {
            this.goodsRepository = goodsRepository;
        }

        public async Task<IActionResult> SearchKey(string goodname)
        {
            if (String.IsNullOrEmpty(goodname))
            {
                return RedirectToAction("SearchError");
            }
            var list = goodsRepository.GetGoods();
            /* list = list.Where(s => s.Name!.ToLower().Contains(keyname.ToLower())).ToList();*/
            list = list.
                Where(x => x.GoodsName.ToLower().Contains(goodname.ToLower())
                || x.Description.ToLower().Contains(goodname.ToLower())
                || x.PhoneNumber.ToString().Contains(goodname.ToLower())
                || x.Category.CategoryName.ToLower().Contains(goodname.ToLower())
                || x.Activity.ActivityName.ToLower().Contains(goodname.ToLower())
                || x.Condition.ConditionName.ToLower().Contains(goodname.ToLower())
                || x.Delivery.DeliveryName.ToLower().Contains(goodname.ToLower())
                || x.Location.LocationName.ToLower().Contains(goodname.ToLower())).ToList();

            ViewBag.Goodes = list;

            return View("Index");
        }

        public IActionResult SearchError()
        {
            ViewBag.Message = "Пошукова стрічка не може бути пустою";
            return View();
        }
    }
}
