using CycleWorld.Data;
using CycleWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Services
{
    public class ShopService
    {
        private readonly Guid _userId;

        public ShopService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateShop(ShopCreate model)
        {
            var entity =
                new Shop()
                {
                    OwnerId = _userId,
                    ShopName = model.ShopName,
                    Services = model.Services,
                    Location = model.Location,
                    CreatedUtc = DateTimeOffset.Now,
                    PartId = model.PartId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shops.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ShopListItem> GetShop()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Shops
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ShopListItem
                                {
                                    ShopId = e.ShopId,
                                    ShopName = e.ShopName,
                                    Location = e.Location,
                                }
                        );

                return query.ToArray();
            }
        }
        public ShopDetail GetShopById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shops
                        .Single(e => e.ShopId == id && e.OwnerId == _userId);
                return
                    new ShopDetail
                    {
                        ShopId = entity.ShopId,
                        ShopName = entity.ShopName,
                        Services = entity.Services,
                        Location = entity.Location,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateShop(ShopEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Shop entity =
                    ctx
                        .Shops
                        .Single(e => e.ShopId == model.ShopId && e.OwnerId == _userId);

                entity.ShopName = model.ShopName;
                entity.Services = model.Services;
                entity.Location = model.Location;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteShop(int shopId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shops
                        .Single(e => e.ShopId == shopId && e.OwnerId == _userId);

                ctx.Shops.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

