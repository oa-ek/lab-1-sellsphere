using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SellSphere.Core;
using SellSphere.Repository.Dto.ActivityDto;
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
        private readonly SellSphereDbContext _ctx;
        private readonly IMapper _mapper;
        public ConditionRepository(SellSphereDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ConditionReadDto>> GetConditionsAsync()
        {
            return _mapper.Map<IEnumerable<ConditionReadDto>>(await _ctx.Conditions.ToListAsync());
        }

        //CREATE
        public async Task<int> AddCondition(ConditionCreateDto condition)
        {
            var data = await _ctx.Conditions.AddAsync(_mapper.Map<Condition>(condition));
            await _ctx.SaveChangesAsync();
            return data.Entity.ConditionId;
        }

        //EDIT
        public async Task<int> UpdateCondition(ConditionReadDto newCondition)
        {
            var conditionInDB = _ctx.Conditions.FirstOrDefault(x => x.ConditionId == newCondition.ConditionId);
            conditionInDB.ConditionName = newCondition.ConditionName;
            await _ctx.SaveChangesAsync();

            var data = _mapper.Map<ConditionReadDto>(conditionInDB);
            return data.ConditionId;
        }

        //DELETE
        public async Task DeleteCondition(int id)
        {
            _ctx.Conditions.Remove(_ctx.Conditions.Find(id));
            _ctx.SaveChanges();
        }
        public async Task<Condition> AddConditionAsync(Condition model)
        {
            _ctx.Conditions.Add(model);
            await _ctx.SaveChangesAsync();
            return _ctx.Conditions.FirstOrDefault(x => x.ConditionName == model.ConditionName);
        }

        public List<Condition> GetConditionTypes()
        {
            var conditionList = _ctx.Conditions.ToList();
            return conditionList;
        }

        public Condition GetCondition(int id)
        {
            return _ctx.Conditions.FirstOrDefault(x => x.ConditionId == id);
        }

        public Condition GetConditionByName(string name)
        {
            return _ctx.Conditions.FirstOrDefault(x => x.ConditionName == name);
        }

        public async Task DeleteConditionAsync(int id)
        {
            _ctx.Remove(GetCondition(id));
            await _ctx.SaveChangesAsync();
        }
    }
}
