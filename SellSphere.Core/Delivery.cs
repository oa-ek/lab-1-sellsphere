using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellSphere.Core
{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }
        public string DeliveryName { get; set; }

        public virtual ICollection<Goods> Goods { get; set; }
    }
}
