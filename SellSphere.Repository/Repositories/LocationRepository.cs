using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SellSphere.Core;
using SellSphere.Repository.Dto.ActivityDto;
using SellSphere.Repository.Dto.LocationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellSphere.Repository.Repositories
{
    public class LocationRepository
    {
        private readonly SellSphereContext _ctx;

        public LocationRepository(SellSphereContext _ctx)
        {
            this._ctx = _ctx;
        }

        public async Task<Location> AddLocationAsync(Location location)
        {
            _ctx.Locations.Add(location);
            await _ctx.SaveChangesAsync();
            return _ctx.Locations.FirstOrDefault(x => x.LocationName == location.LocationName);
        }

        public Location GetLocation(int id)
        {
            return _ctx.Locations.FirstOrDefault(x => x.LocationId == id);
        }
        public Location GetLocationByName(string name)
        {
            return _ctx.Locations.FirstOrDefault(x => x.LocationName == name);
        }

        public List<Location> GetLocations()
        {
            var locationList = _ctx.Locations.ToList();
            return locationList;
        }

        public async Task DeleteLocationAsync(int id)
        {
            _ctx.Remove(GetLocation(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateLocationAsync(Location updatedLocation)
        {
            var location = _ctx.Locations.FirstOrDefault(x => x.LocationId == updatedLocation.LocationId);

            location.LocationName = updatedLocation.LocationName;
            await _ctx.SaveChangesAsync();
        }
    }
}
