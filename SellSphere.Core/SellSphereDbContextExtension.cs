using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SellSphere.Core
{
    public static class SellSphereDbContextExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string MODER_ROLE_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = MODER_ROLE_ID,
                    Name = "Moderator",
                    NormalizedName = "MODERATOR"
                },
                new IdentityRole
                {
                    Id = USER_ROLE_ID,
                    Name = "User",
                    NormalizedName = "USER"
                });

            string ADMIN_ID = Guid.NewGuid().ToString();
            string MODER_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();

            var admin = new User
            {
                Id = ADMIN_ID,
                UserName = "admin@sellsphere.com",
                Email = "admin@sellsphere.com",
                EmailConfirmed = true,
                NormalizedEmail = "admin@sellsphere.com".ToUpper(),
                NormalizedUserName = "admin@sellsphere.com".ToUpper()
            };

            var moder = new User
            {
                Id = MODER_ID,
                UserName = "moder@sellsphere.com",
                Email = "moder@sellsphere.com",
                EmailConfirmed = true,
                NormalizedEmail = "moder@sellsphere.com".ToUpper(),
                NormalizedUserName = "moder@sellsphere.com".ToUpper()
            };

            var user = new User
            {
                Id = USER_ID,
                UserName = "user@sellsphere.com",
                Email = "user@sellsphere.com",
                EmailConfirmed = true,
                NormalizedEmail = "user@sellsphere.com".ToUpper(),
                NormalizedUserName = "user@sellsphere.com".ToUpper(),
            };

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            admin.PasswordHash = hasher.HashPassword(admin, "Admin$pass1");
            moder.PasswordHash = hasher.HashPassword(moder, "Moder$pass1");
            user.PasswordHash = hasher.HashPassword(user, "User$pass1");

            builder.Entity<User>().HasData(admin, moder, user);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = MODER_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = MODER_ROLE_ID,
                    UserId = MODER_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = MODER_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                });

            builder.Entity<Activity>().HasData(
                new Activity
                {
                    ActivityId = 1,
                    ActivityName = "Приватний",
                },
                new Activity
                {
                    ActivityId = 2,
                    ActivityName = "Бізнес",
                });

            builder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Тварини",
                },
                 new Category
                 {
                     CategoryId = 2,
                     CategoryName = "Електроніка",
                 },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Бізнес та послуги",
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Хобі, відпочинок і спорт",
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Дім та сад",
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Дитячий світ",
                },
                new Category
                {
                    CategoryId = 7,
                    CategoryName = "Мода і стиль",
                });

            builder.Entity<Condition>().HasData(
                new Condition
                {
                    ConditionId = 1,
                    ConditionName = "Новий",
                },
                new Condition
                {
                    ConditionId = 2,
                    ConditionName = "Б/У",
                });

           

            builder.Entity<Delivery>().HasData(
                new Delivery
                {
                    DeliveryId = 1,
                    DeliveryName = "Нова Пошта",
                },
                new Delivery
                {
                    DeliveryId = 2,
                    DeliveryName = "Укрпошта",
                },
                  new Delivery
                  {
                      DeliveryId = 3,
                      DeliveryName = "Meest",
                  });

            builder.Entity<Location>().HasData(
                new Location
                {
                    LocationId = 1,
                    LocationName = "Чернігів",
                },
                new Location
                {
                    LocationId = 2,
                    LocationName = "Київ",
                    
                },
                 new Location
                 {
                     LocationId = 3,
                     LocationName = "Луцьк",
                 },
                  new Location
                  {
                      LocationId = 4,
                      LocationName = "Житомир",
                  },
                   new Location
                   {
                       LocationId = 5,
                       LocationName = "Рівне",
                   });

            builder.Entity<Goods>().HasData(
                 new Goods
                 {
                     GoodsId = 1,
                     GoodsName = "Ноутбук",
                     PublicationDate = new DateTime(2023, 09, 10),
                     Price = 35440,
                     DeliveryId = 1,
                     CategoryId = 2,
                     ActivityId = 1,
                     ConditionId = 2,
                     Description = "ноутбук в гарному стані, є невеликі подряпини, екран не битий, 15.6 дюймів",
                     PhoneNumber = "0685894567",
                     ImgPath = @"\Images\acer.jpg",
                     LocationId = 1,
                     UserId = USER_ID
                 },

                   new Goods
                   {
                       GoodsId = 2,
                       GoodsName = "Велосипед",
                       PublicationDate = new DateTime(2023, 10, 25),
                       Price = 66700,
                       DeliveryId = 1,
                       CategoryId = 4,
                       ActivityId = 1,
                       ConditionId = 2,
                       Description = "Велосипед використовувався 1 рік, є незначні пошкодженння, ТО робилося кожних 200 км",
                       PhoneNumber = "0975894567",
                       ImgPath = @"\Images\velik.jpg",
                       LocationId = 3,
                       UserId = USER_ID
                   }
                 );
        }
    }
}
