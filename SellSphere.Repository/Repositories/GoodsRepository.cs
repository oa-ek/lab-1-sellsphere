using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly SellSphereDbContext _ctx;
        private readonly IMapper _mapper;
        public GoodsRepository(SellSphereDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }


        public async Task<IEnumerable<GoodsReadDto>> GetGoodsAsync()
        {
            return _mapper.Map<IEnumerable<GoodsReadDto>>(await _ctx.Goodes.Include(x => x.Activity).Include(x => x.Category).Include(x => x.Condition).Include(x => x.Contacts).Include(x => x.Delivery).Include(x => x.Location).ToListAsync());
        }

        public async Task<GoodsReadDto> GetAsync(int id)
        {
            return _mapper.Map<GoodsReadDto>(await _ctx.Goodes.Include(x => x.Activity).Include(x => x.Category).FirstAsync());
        }

        //CREATE
        public async Task<int> AddGood(GoodsCreateDto good)
        {
            var data = await _ctx.Goodes.AddAsync(_mapper.Map<Goods>(good));
            await _ctx.SaveChangesAsync();
            return data.Entity.GoodsId;
        }

        //DELETE
        public async Task DeleteGood(int id)
        {
            _ctx.Goodes.Remove(_ctx.Goodes.Find(id));
            _ctx.SaveChanges();
        }
        public async Task<Goods> AddGoodsAsync(Goods good)
        {
            _ctx.Goodes.Add(good);
            await _ctx.SaveChangesAsync();
            return _ctx.Goodes.Include(x => x.Activity).
                Include(x => x.Category).
                Include(x => x.Condition).
                Include(x => x.Contacts).
                Include(x => x.Delivery).
                Include(x => x.Location).
                Include(x => x.User).FirstOrDefault(x => x.Activity.ActivityName == good.Activity.ActivityName);
        }

        public Goods GetGoods(int id)
        {
            return _ctx.Goodes.Include(x => x.Activity).
                Include(x => x.Category).
                Include(x => x.Condition).
                Include(x => x.Contacts).
                Include(x => x.Delivery).
                Include(x => x.Location).
                Include(x => x.User).FirstOrDefault(x => x.GoodsId == id);
        }

        public List<Goods> GetGoodes()
        {
            var goodList = _ctx.Goodes.Include(x => x.Activity).
                 Include(x => x.Category).
                 Include(x => x.Condition).
                 Include(x => x.Contacts).
                 Include(x => x.Delivery).
                 Include(x => x.Location).
                 Include(x => x.User).ToList();

            return goodList;
        }

        /*public async Task<GoodsReadDto> GetGoodsDto(int id)
        {
            var g = await _ctx.Goodes.Include(x => x.Activity).
                 Include(x => x.Category).
                 Include(x => x.Condition).
                 Include(x => x.Contacts).
                 Include(x => x.Delivery).
                 Include(x => x.Location).
                 Include(x => x.User).FirstAsync(x => x.GoodsId == id);

            var goodDto = new GoodsReadDto
            {
                GoodsId = g.GoodsId,
                GoodsName = g.GoodsName,
                PublicationDate = g.PublicationDate,
                ActivityName = g.Activity.ActivityName,
                CategoryName = g.Category.CategoryName,
                ConditionName = g.Condition.ConditionName,
                ContactsPerson = g.Contacts.ContactPerson,
                DeliveryName = g.Delivery.DeliveryName,
                LocationName = g.Location.LocationName,
                GoodIconPath = g.GoodIconPath,
                Price = g.Price,
                Description = g.Description,
                
                UserId = g.UserId,
            };
            return goodDto;
        }*/

        public async Task UpdateAsync(GoodsReadDto goodDto, string activityName, string categoryName,
            string conditionName, string contactsName, string deliveryName, string locationName)
        {
            var vehicle = _ctx.Goodes.Include(x => x.Activity).
                 Include(x => x.Category).
                 Include(x => x.Condition).
                 Include(x => x.Contacts).
                 Include(x => x.Delivery).
                 Include(x => x.Location).
                 Include(x => x.User).FirstOrDefault(x => x.GoodsId == goodDto.GoodsId);

            if (vehicle.Activity.ActivityName != activityName)
                vehicle.Activity = _ctx.Activities.FirstOrDefault(x => x.ActivityName == activityName);

            if (vehicle.Category.CategoryName != categoryName)
                vehicle.Category = _ctx.Categories.FirstOrDefault(x => x.CategoryName == categoryName);

            if (vehicle.Condition.ConditionName != conditionName)
                vehicle.Condition = _ctx.Conditions.FirstOrDefault(x => x.ConditionName == conditionName);

            if (vehicle.Contacts.ContactPerson != contactsName)
                vehicle.Contacts = _ctx.Contactses.FirstOrDefault(x => x.ContactPerson == contactsName);

            if (vehicle.Price != goodDto.Price)
                vehicle.Price = goodDto.Price;

           

            if (vehicle.Delivery.DeliveryName != deliveryName)
                vehicle.Delivery = _ctx.Deliveries.FirstOrDefault(x => x.DeliveryName == deliveryName);

       

            if (vehicle.GoodIconPath != goodDto.GoodIconPath)
                vehicle.GoodIconPath = goodDto.GoodIconPath;

            if (vehicle.Location.LocationName != locationName)
                vehicle.Location = _ctx.Locations.FirstOrDefault(x => x.LocationName == locationName);

            if (vehicle.Description != goodDto.Description)
                vehicle.Description = goodDto.Description;

            _ctx.SaveChanges();
        }

        public async Task DeleteGoodsAsync(int id)
        {
            _ctx.Remove(GetGoods(id));
            await _ctx.SaveChangesAsync();
        }
    }
}
