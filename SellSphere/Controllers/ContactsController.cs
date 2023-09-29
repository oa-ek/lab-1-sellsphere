using Microsoft.AspNetCore.Mvc;
using SellSphere.Repository.Dto.Condition;
using SellSphere.Repository.Dto.ContactsDto;
using SellSphere.Repository.Repositories;

namespace SellSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly ContactsRepository _contactsRepository;
        public ContactsController(ILogger<ContactsController> logger, ContactsRepository contactsRepository)
        {
            _logger = logger;
            _contactsRepository = contactsRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<ContactsReadDto>> GetListAsync()
        {
            return await _contactsRepository.GetContactsesAsync();
        }

        /// <summary>
        /// Create author
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost]
        public async Task<int> AddContacts(ContactsCreateDto dto)
        {
            return await _contactsRepository.AddContacts(dto);
        }

        /// <summary>
        /// Update author
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public async Task<int> EditContacts(ContactsReadDto contacts)
        {
            return await _contactsRepository.UpdateContacts(contacts);
        }

        /// <summary>
        /// Delete author by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _contactsRepository.DeleteContacts(id);
        }
    }
}
