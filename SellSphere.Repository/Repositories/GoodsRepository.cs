using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SellSphere.Core;
using SellSphere.Repository.Dto.GoodsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellSphere.Repository.Repositories
{
    public class GoodsRepository
    {
        private readonly SellSphereContext _ctx;
        public GoodsRepository(SellSphereContext _ctx)
        {
            this._ctx = _ctx;
        }

        public async Task<Goods> AddGoodAsync(Goods good)
        {
            _ctx.Goodes.Add(good);
            await _ctx.SaveChangesAsync();
            return _ctx.Goodes.Include(x => x.Category).Include(x => x.Activity).Include(x => x.Condition).Include(x => x.Delivery).Include(x => x.Location).FirstOrDefault(x => x.GoodsName == good.GoodsName);
        }

        public Goods GetGoods(int id)
        {
            return _ctx.Goodes.Include(x => x.Category).Include(x => x.Activity).Include(x => x.Condition).Include(x => x.Delivery).Include(x => x.Location).FirstOrDefault(x => x.GoodsId == id);
        }

        public List<Goods> GetGoods()
        {
            var goodList = _ctx.Goodes.Include(x => x.Category).Include(x => x.Activity).Include(x => x.Condition).Include(x => x.Delivery).Include(x => x.Location).ToList();
            return goodList;
        }

        public async Task DeleteGoodsAsync(int id)
        {
            _ctx.Remove(GetGoods(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateGoodsAsync(Goods updatedGoods)
        {
            var good = _ctx.Goodes.FirstOrDefault(x => x.GoodsId == updatedGoods.GoodsId);
            good.GoodsName = updatedGoods.GoodsName;
            good.Description = updatedGoods.Description;
            good.Price = updatedGoods.Price;
            
            good.ImgPath = updatedGoods.ImgPath;
           
            good.Category = updatedGoods.Category;
            good.Activity = updatedGoods.Activity;
            good.Condition = updatedGoods.Condition;
            good.Delivery = updatedGoods.Delivery;
            good.Location = updatedGoods.Location;

            await _ctx.SaveChangesAsync();
        }

        public async Task<GoodsCreateDto> GetGoodsDto(int id)
        {
            var g = await _ctx.Goodes.Include(x => x.Category).Include(x => x.Activity).Include(x => x.Condition).Include(x => x.Delivery).Include(x => x.Location).FirstAsync(x => x.GoodsId == id);

            var goodDto = new GoodsCreateDto
            {
                GoodsId = g.GoodsId,
                GoodsName = g.GoodsName,
                Description = g.Description,
                Price = g.Price,
               
                ImgPath = g.ImgPath,
               
                CategoryName = g.Category.CategoryName,
                ActivityName = g.Activity.ActivityName,
                ConditionName = g.Condition.ConditionName,

                DeliveryName = g.Delivery.DeliveryName,
                LocationName = g.Location.LocationName
            };
            return goodDto;
        }

        public async Task UpdateAsync(GoodsCreateDto model, string categories, string activities, string conditions, string contacts, string deliveries, string locations)
        {
            var good = _ctx.Goodes.Include(x => x.Category).Include(x => x.Activity).Include(x => x.Condition).Include(x => x.Delivery).Include(x => x.Location).FirstOrDefault(x => x.GoodsId == model.GoodsId);
            if (good.GoodsName != model.GoodsName)
                good.GoodsName = model.GoodsName;

            if (good.Description != model.Description)
                good.Description = model.Description;

            if (good.Price != model.Price)
                good.Price = model.Price;



            if (good.ImgPath != model.ImgPath)
                good.ImgPath = model.ImgPath;
            
            if (good.Category.CategoryName != categories)
                good.Category = _ctx.Categories.FirstOrDefault(x => x.CategoryName == categories);

            if (good.Activity.ActivityName != activities)
                good.Activity = _ctx.Activities.FirstOrDefault(x => x.ActivityName == activities);

            if (good.Condition.ConditionName != conditions)
                good.Condition = _ctx.Conditions.FirstOrDefault(x => x.ConditionName == conditions);

         

            if (good.Delivery.DeliveryName != deliveries)
                good.Delivery = _ctx.Deliveries.FirstOrDefault(x => x.DeliveryName == deliveries);

            if (good.Location.LocationName != locations)
                good.Location = _ctx.Locations.FirstOrDefault(x => x.LocationName == locations);

            _ctx.SaveChanges();
        }
    }
}
