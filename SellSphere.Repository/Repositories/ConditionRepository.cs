using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SellSphere.Core;

using SellSphere.Repository.Dto.Condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellSphere.Repository.Repositories
{
    public class ConditionRepository
    {
        private readonly SellSphereContext _ctx;

        public ConditionRepository(SellSphereContext _ctx)
        {
            this._ctx = _ctx;
        }

        public async Task<Condition> AddConditionAsync(Condition condition)
        {
            _ctx.Conditions.Add(condition);
            await _ctx.SaveChangesAsync();
            return _ctx.Conditions.FirstOrDefault(x => x.ConditionName == condition.ConditionName);
        }

        public Condition GetCondition(int id)
        {
            return _ctx.Conditions.FirstOrDefault(x => x.ConditionId == id);
        }
        public Condition GetConditionByName(string name)
        {
            return _ctx.Conditions.FirstOrDefault(x => x.ConditionName == name);
        }

        public List<Condition> GetConditions()
        {
            var conditionList = _ctx.Conditions.ToList();
            return conditionList;
        }

        public async Task DeleteConditionAsync(int id)
        {
            _ctx.Remove(GetCondition(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateConditionAsync(Condition updatedCondition)
        {
            var condition = _ctx.Conditions.FirstOrDefault(x => x.ConditionId == updatedCondition.ConditionId);

            condition.ConditionName = updatedCondition.ConditionName;
            await _ctx.SaveChangesAsync();
        }
    }
}
