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
        private readonly SellSphereContext _ctx;

        public ActivityRepository(SellSphereContext _ctx)
        {
            this._ctx = _ctx;
        }

        public async Task<Activity> AddActivityAsync(Activity activity)
        {
            _ctx.Activities.Add(activity);
            await _ctx.SaveChangesAsync();
            return _ctx.Activities.FirstOrDefault(x => x.ActivityName == activity.ActivityName);
        }

        public Activity GetActivity(int id)
        {
            return _ctx.Activities.FirstOrDefault(x => x.ActivityId == id);
        }
        public Activity GetActivityByName(string name)
        {
            return _ctx.Activities.FirstOrDefault(x => x.ActivityName == name);
        }

        public List<Activity> GetActivities()
        {
            var activityList = _ctx.Activities.ToList();
            return activityList;
        }

        public async Task DeleteActivityAsync(int id)
        {
            _ctx.Remove(GetActivity(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateActivityAsync(Activity updatedActivity)
        {
            var activity = _ctx.Activities.FirstOrDefault(x => x.ActivityId == updatedActivity.ActivityId);

            activity.ActivityName = updatedActivity.ActivityName;
            await _ctx.SaveChangesAsync();
        }
    }
}
