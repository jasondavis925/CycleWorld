


using CycleWorld.Data;
using CycleWorld.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Services
{
    public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    PersonalId = _userId,
                    Name = model.Name,
                    Bio = model.Bio,
                    ShopId = model.ShopId,
                    CreatedUtc = DateTimeOffset.Now,
                    BikeId = model.BikeId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Where(e => e.PersonalId == _userId)
                        .Select(
                            e =>
                                new UserListItem
                                {
                                    UserId = e.UserId,
                                    Name = e.Name,
                                    CreatedUtc = e.CreatedUtc,
                                    ShopId = e.ShopId,
                                    ShopName = e.Shop.ShopName,
                                    BikeId = e.BikeId,
                                    //BikeMake = e.Bike.Make,
                                    //BikeModel = e.Bike.Model,
                                    //BikeYear = e.Bike.Year
                                }
                        );

                return query.ToArray();
            }
        }
        public UserDetail GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.UserId == id && e.PersonalId == _userId);
                return
                    new UserDetail
                    {
                        UserId = entity.UserId,
                        Name = entity.Name,
                        Bio = entity.Bio,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                        ShopId = entity.ShopId,
                        Shop = new ShopListItem()
                        {
                            ShopId = entity.Shop.ShopId,
                            ShopName = entity.Shop.ShopName,
                            Location = entity.Shop.Location
                        },
                        BikeId = entity.BikeId,
                        Bike = new BikeListItem()
                        {
                            BikeId = entity.Bike.BikeId,
                            Model = entity.Bike.Model,
                            Make = entity.Bike.Make,
                            Year = entity.Bike.Year
                        }
                    };
            }
        }
        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                User entity =
                    ctx
                        .Users
                        .Single(e => e.UserId == model.UserId && e.PersonalId == _userId);

                entity.Name = model.Name;
                entity.Bio = model.Bio;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                entity.BikeId = model.BikeId;
                entity.ShopId = model.ShopId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteUser(int userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.UserId == userId && e.PersonalId == _userId);

                ctx.Users.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
