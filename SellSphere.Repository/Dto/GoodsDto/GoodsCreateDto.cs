using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellSphere.Repository.Dto.GoodsDto
{
    public class GoodsCreateDto
    {
        [Required]
        public int? GoodsId { get; set; }

        [Required]
        public string? GoodsName { get; set; }

        [Required]
        public string? ActivityName { get; set; }

        public DateTime PublicationDate { get; set; } = DateTime.Now;

        [Required]
        public string? CategoryName { get; set; }

        [Required]
        public string? ConditionName { get; set; }


        [Required]
        public string? DeliveryName { get; set; }

        [Required]
        public string? LocationName { get; set; }



        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Must be a valid Price")]
        public int Price { get; set; }

        [Required]
        public string? ImgPath { get; set; }


        [Required]
        public string? Description { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        public string? UserId { get; set; }
    }
}
