using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SellSphere.Core;
using SellSphere.Repository.Dto.ActivityDto;
using SellSphere.Repository.Dto.CategoryDto;
using SellSphere.Repository.Dto.ContactsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellSphere.Repository.Repositories
{
    public class ContactsRepository
    {
        private readonly SellSphereDbContext _ctx;
        private readonly IMapper _mapper;
        public ContactsRepository(SellSphereDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ContactsReadDto>> GetContactsesAsync()
        {
            return _mapper.Map<IEnumerable<ContactsReadDto>>(await _ctx.Contactses.ToListAsync());
        }


        //CREATE
        public async Task<int> AddContacts(ContactsCreateDto category)
        {
            var data = await _ctx.Contactses.AddAsync(_mapper.Map<Contacts>(category));
            await _ctx.SaveChangesAsync();
            return data.Entity.ContactsId;
        }

        //EDIT
        public async Task<int> UpdateContacts(ContactsReadDto newContacts)
        {
            var contactsInDB = _ctx.Contactses.FirstOrDefault(x => x.ContactsId == newContacts.ContactsId);
            contactsInDB.ContactPerson = newContacts.ContactPerson;
            await _ctx.SaveChangesAsync();

            var data = _mapper.Map<ContactsReadDto>(contactsInDB);
            return data.ContactsId;
        }

        //DELETE
        public async Task DeleteContacts(int id)
        {
            _ctx.Contactses.Remove(_ctx.Contactses.Find(id));
            _ctx.SaveChanges();
        }



        public async Task<Contacts> AddContactsAsync(Contacts model)
        {
            _ctx.Contactses.Add(model);
            await _ctx.SaveChangesAsync();
            return _ctx.Contactses.FirstOrDefault(x => x.ContactPerson == model.ContactPerson);
        }

        public List<Contacts> GetContactsTypes()
        {
            var contactsList = _ctx.Contactses.ToList();
            return contactsList;
        }

        public Contacts GetContacts(int id)
        {
            return _ctx.Contactses.FirstOrDefault(x => x.ContactsId == id);
        }

        public Contacts GetContactsByName(string name)
        {
            return _ctx.Contactses.FirstOrDefault(x => x.ContactPerson == name);
        }

        public async Task DeleteContactsAsync(int id)
        {
            _ctx.Remove(GetContacts(id));
            await _ctx.SaveChangesAsync();
        }
    }
}
