using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellSphere.Core
{
    public class Goods
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public DateTime PublicationDate { get; set; } = DateTime.Now;

        public int Price {  get; set; }

        public int DeliveryId { get; set; }
        public Delivery? Delivery { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int ActivityId { get; set; }
        public Activity? Activity { get; set; }

        public int ConditionId { get; set; }
        public Condition? Condition { get; set; }

        public string Description { get; set; }

        public string? ImgPath { get; set; }
       
        public string PhoneNumber { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }

        

        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
