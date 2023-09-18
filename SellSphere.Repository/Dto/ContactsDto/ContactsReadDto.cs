using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellSphere.Repository.Dto.ContactsDto
{
    public class ContactsReadDto
    {
        public int ContactsId { get; set; }
        public string ContactPerson { get; set; }

        public string EmailPerson { get; set; }

        public string PhoneNumberPerson { get; set; }
    }
}
