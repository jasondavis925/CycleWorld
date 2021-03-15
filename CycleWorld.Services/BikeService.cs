using CycleWorld.Data;
using CycleWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleWorld.Services
{
    public class BikeService
    {
        private readonly Guid _ownerId;

        public BikeService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        public bool CreateBike(BikeCreate model)
        {
            var entity =
                new Bike()
                {
                    Model = model.Model,
                    OwnerId = _ownerId,
                    Make = model.Make,
                    Year = model.Year,
                    CreatedUtc = DateTimeOffset.Now,
                    Mileage = model.Mileage
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Bikes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BikeListItem> GetBikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Bikes
                        .Select(
                            e =>
                                new BikeListItem
                                {
                                    BikeId = e.BikeId,
                                    Model = e.Model,
                                    Make = e.Make,
                                    Year = e.Year,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public BikeDetail GetBikeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Bikes
                        .Single(e => e.BikeId == id && e.OwnerId == _ownerId);
                return
                    new BikeDetail
                    {
                        BikeId = entity.BikeId,
                        Model = entity.Model,
                        Make = entity.Make,
                        Year = entity.Year,
                        Mileage = entity.Mileage,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateBike(BikeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Bike entity =
                    ctx
                        .Bikes
                        .Single(e => e.BikeId == model.BikeId && e.OwnerId == _ownerId);

                entity.Model = model.Model;
                entity.Make = model.Make;
                entity.Mileage = model.Mileage;
                entity.Year = model.Year;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBike(int bikeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Bikes
                    .Single(e => e.BikeId == bikeId);

                ctx.Bikes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
