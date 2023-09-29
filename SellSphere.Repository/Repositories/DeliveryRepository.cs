using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SellSphere.Core;
using SellSphere.Repository.Dto.ActivityDto;
using SellSphere.Repository.Dto.ContactsDto;
using SellSphere.Repository.Dto.DeliveryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellSphere.Repository.Repositories
{
    public class DeliveryRepository
    {
        private readonly SellSphereDbContext _ctx;
        private readonly IMapper _mapper;
        public DeliveryRepository(SellSphereDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }


        public async Task<IEnumerable<DeliveryReadDto>> GetDeliveriesAsync()
        {
            return _mapper.Map<IEnumerable<DeliveryReadDto>>(await _ctx.Deliveries.ToListAsync());
        }


        //CREATE
        public async Task<int> AddDelivery(DeliveryCreateDto category)
        {
            var data = await _ctx.Deliveries.AddAsync(_mapper.Map<Delivery>(category));
            await _ctx.SaveChangesAsync();
            return data.Entity.DeliveryId;
        }

        //EDIT
        public async Task<int> UpdateDelivery(DeliveryReadDto newDelivery)
        {
            var deliveryInDB = _ctx.Deliveries.FirstOrDefault(x => x.DeliveryId == newDelivery.DeliveryId);
            deliveryInDB.DeliveryName = newDelivery.DeliveryName;
            await _ctx.SaveChangesAsync();

            var data = _mapper.Map<DeliveryReadDto>(deliveryInDB);
            return data.DeliveryId;
        }

        //DELETE
        public async Task DeleteDelivery(int id)
        {
            _ctx.Deliveries.Remove(_ctx.Deliveries.Find(id));
            _ctx.SaveChanges();
        }

        public async Task<Delivery> AddDeliveryAsync(Delivery model)
        {
            _ctx.Deliveries.Add(model);
            await _ctx.SaveChangesAsync();
            return _ctx.Deliveries.FirstOrDefault(x => x.DeliveryName == model.DeliveryName);
        }

        public List<Delivery> GetDeliveryTypes()
        {
            var deliveryList = _ctx.Deliveries.ToList();
            return deliveryList;
        }

        public Delivery GetDelivery(int id)
        {
            return _ctx.Deliveries.FirstOrDefault(x => x.DeliveryId == id);
        }

        public Delivery GetDeliveryByName(string name)
        {
            return _ctx.Deliveries.FirstOrDefault(x => x.DeliveryName == name);
        }

        public async Task DeleteDeliveryAsync(int id)
        {
            _ctx.Remove(GetDelivery(id));
            await _ctx.SaveChangesAsync();
        }
    }
}
