using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using SellSphere.Core;
using SellSphere.Repository.Dto.ActivityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellSphere.Repository.Repositories
{
    public class ActivityRepository
    {
        private readonly SellSphereDbContext _ctx;
        private readonly IMapper _mapper;
        public ActivityRepository(SellSphereDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActivityReadDto>> GetActivitiesAsync()
        {
            return _mapper.Map<IEnumerable<ActivityReadDto>>(await _ctx.Activities.ToListAsync());
        }
        public async Task<Activity> AddActivityAsync(Activity model)
        {
            _ctx.Activities.Add(model);
            await _ctx.SaveChangesAsync();
            return _ctx.Activities.FirstOrDefault(x => x.ActivityName == model.ActivityName);
        }

        public List<Activity> GetActivityTypes()
        {
            var activityList = _ctx.Activities.ToList();
            return activityList;
        }

        public Activity GetActivity(int id)
        {
            return _ctx.Activities.FirstOrDefault(x => x.ActivityId == id);
        }

        public Activity GetActivityByName(string name)
        {
            return _ctx.Activities.FirstOrDefault(x => x.ActivityName == name);
        }

        public async Task DeleteActivityAsync(int id)
        {
            _ctx.Remove(GetActivity(id));
            await _ctx.SaveChangesAsync();
        }
    }
}
