using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SellSphere.Core;
using SellSphere.Repository.Dto.ActivityDto;
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
        private readonly SellSphereContext _ctx;

        public DeliveryRepository(SellSphereContext _ctx)
        {
            this._ctx = _ctx;
        }

        public async Task<Delivery> AddDeliveryAsync(Delivery delivery)
        {
            _ctx.Deliveries.Add(delivery);
            await _ctx.SaveChangesAsync();
            return _ctx.Deliveries.FirstOrDefault(x => x.DeliveryName == delivery.DeliveryName);
        }

        public Delivery GetDelivery(int id)
        {
            return _ctx.Deliveries.FirstOrDefault(x => x.DeliveryId == id);
        }
        public Delivery GetDeliveryByName(string name)
        {
            return _ctx.Deliveries.FirstOrDefault(x => x.DeliveryName == name);
        }

        public List<Delivery> GetDeliveries()
        {
            var deliveryList = _ctx.Deliveries.ToList();
            return deliveryList;
        }

        public async Task DeleteDeliveryAsync(int id)
        {
            _ctx.Remove(GetDelivery(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateDeliveryAsync(Delivery updatedDelivery)
        {
            var delivery = _ctx.Deliveries.FirstOrDefault(x => x.DeliveryId == updatedDelivery.DeliveryId);

            delivery.DeliveryName = updatedDelivery.DeliveryName;
            await _ctx.SaveChangesAsync();
        }
    }
}
