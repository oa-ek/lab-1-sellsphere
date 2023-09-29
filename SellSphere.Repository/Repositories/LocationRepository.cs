using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SellSphere.Core;
using SellSphere.Repository.Dto.ActivityDto;
using SellSphere.Repository.Dto.DeliveryDto;
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
        private readonly SellSphereDbContext _ctx;
        private readonly IMapper _mapper;
        public LocationRepository(SellSphereDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocationReadDto>> GetLocationsAsync()
        {
            return _mapper.Map<IEnumerable<LocationReadDto>>(await _ctx.Locations.ToListAsync());
        }


        //CREATE
        public async Task<int> AddLocation(LocationCreateDto category)
        {
            var data = await _ctx.Locations.AddAsync(_mapper.Map<Location>(category));
            await _ctx.SaveChangesAsync();
            return data.Entity.LocationId;
        }

        //EDIT
        public async Task<int> UpdateLocation(LocationReadDto newLocation)
        {
            var locationInDB = _ctx.Locations.FirstOrDefault(x => x.LocationId == newLocation.LocationId);
            locationInDB.LocationName = newLocation.LocationName;
            await _ctx.SaveChangesAsync();

            var data = _mapper.Map<LocationReadDto>(locationInDB);
            return data.LocationId;
        }

        //DELETE
        public async Task DeleteLocation(int id)
        {
            _ctx.Locations.Remove(_ctx.Locations.Find(id));
            _ctx.SaveChanges();
        }

        public async Task<Location> AddLocationAsync(Location model)
        {
            _ctx.Locations.Add(model);
            await _ctx.SaveChangesAsync();
            return _ctx.Locations.FirstOrDefault(x => x.LocationName == model.LocationName);
        }

        public List<Location> GetLocationTypes()
        {
            var locationList = _ctx.Locations.ToList();
            return locationList;
        }

        public Location GetLocation(int id)
        {
            return _ctx.Locations.FirstOrDefault(x => x.LocationId == id);
        }

        public Location GetLocationByName(string name)
        {
            return _ctx.Locations.FirstOrDefault(x => x.LocationName == name);
        }

        public async Task DeleteLocationAsync(int id)
        {
            _ctx.Remove(GetLocation(id));
            await _ctx.SaveChangesAsync();
        }
    }
}
