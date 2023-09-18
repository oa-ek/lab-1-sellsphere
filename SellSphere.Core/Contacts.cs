using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellSphere.Core
{
    public class Contacts
    {
        [Key]
        public int ContactsId { get; set; }
        public string ContactPerson { get; set; }

        public string EmailPerson { get; set; }

        public string PhoneNumberPerson { get; set; }

        public virtual ICollection<Goods> Goods { get; set; }
    }
}
