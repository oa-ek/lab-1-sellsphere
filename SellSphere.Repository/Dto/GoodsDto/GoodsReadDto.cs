using SellSphere.Repository.Dto.ActivityDto;
using SellSphere.Repository.Dto.CategoryDto;
using SellSphere.Repository.Dto.Condition;
using SellSphere.Repository.Dto.ContactsDto;
using SellSphere.Repository.Dto.DeliveryDto;
using SellSphere.Repository.Dto.LocationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellSphere.Repository.Dto.GoodsDto
{
    public class GoodsReadDto
    {
        public int GoodsId { get; set; }
        public string? GoodsName { get; set; }
        public DateTime PublicationDate { get; set; } = DateTime.Now;
        //public string? ActivityName { get; set; }
        public ActivityReadDto Activity { get; set; }
        //public string? CategoryName { get; set; }
        public CategoryReadDto Category { get; set; }
        //public string? ConditionName { get; set; }
        public ConditionReadDto Conditions { get; set; }
        //public string? DeliveryName { get; set; }
        public DeliveryReadDto Delivery { get; set; }
        //public string? ContactsPerson { get; set; }
        public ContactsReadDto Contacts { get; set; }
        // public string? LocationName { get; set; }
        public LocationReadDto Location { get; set; }

        public int Price { get; set; }

        public string? GoodIconPath { get; set; }

        public string? Description { get; set; }


        public string? UserId { get; set; }
    }
}
