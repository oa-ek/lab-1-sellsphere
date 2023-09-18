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
    }
}
