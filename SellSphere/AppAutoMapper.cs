using AutoMapper;
using SellSphere.Core;
using SellSphere.Repository.Dto.ActivityDto;
using SellSphere.Repository.Dto.CategoryDto;
using SellSphere.Repository.Dto.Condition;

using SellSphere.Repository.Dto.DeliveryDto;
using SellSphere.Repository.Dto.GoodsDto;
using SellSphere.Repository.Dto.LocationDto;
using SellSphere.Repository.Dto.UserDto;

namespace SellSphere
{
    public class AppAutoMapper : Profile
    {
        public AppAutoMapper()
        {
            CreateMap<GoodsReadDto, Goods>();
            CreateMap<Goods, GoodsReadDto>();
            CreateMap<GoodsCreateDto, Goods>();
            CreateMap<Goods, GoodsCreateDto>();

            CreateMap<ActivityReadDto, Goods>();
            CreateMap<Goods, ActivityReadDto>();

            CreateMap<CategoryReadDto, Category>();
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<Category, CategoryCreateDto>();

            CreateMap<ConditionReadDto, Condition>();
            CreateMap<Condition, ConditionReadDto>();
            CreateMap<ConditionCreateDto, Condition>();
            CreateMap<Condition, ConditionCreateDto>();

           

            CreateMap<DeliveryReadDto, Delivery>();
            CreateMap<Delivery, DeliveryReadDto>();
            CreateMap<DeliveryCreateDto, Delivery>();
            CreateMap<Delivery, DeliveryCreateDto>();

            CreateMap<LocationReadDto, Location>();
            CreateMap<Location, LocationReadDto>();
            CreateMap<LocationCreateDto, Location>();
            CreateMap<Location, LocationCreateDto>();

            CreateMap<ActivityReadDto, Activity>();
            CreateMap<Activity, ActivityReadDto>();
            CreateMap<ActivityCreateDto, Activity>();
            CreateMap<Activity, ActivityCreateDto>();

            CreateMap<UserReadDto, User>();
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserCreateDto>();

            
        }
    }
}
