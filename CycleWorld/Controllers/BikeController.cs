
using CycleWorld.Models;
using CycleWorld.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CycleWorld.Controllers
{
    public class BikeController : ApiController
    {
        //private BikeService _bikeService = new BikeService();

        //public IHttpActionResult Post(BikeCreate bike)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var service = BikeService;
        //    if (.CreateBike(bike))
        //        return InternalServerError();

        //    return Ok();
        //}

        //public IHttpActionResult Get()
        //{
        //    BikeService bikeService = 
        //}

        //public IHttpActionResult Get(int id)
        //{
        //    var bike = _bikeService.GetBikeById(id);
        //    return Ok(bike);
        //}

        //public IHttpActionResult Put(BikeEdit bike)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    if (!_bikeService.UpdateBike(bike))
        //    {
        //        return InternalServerError();
        //    }

        //    return Ok();
        //}

        //public IHttpActionResult Delete(int id)
        //{
        //    if (_bikeService.DeleteBike(id))
        //    {
        //        return InternalServerError();
        //    }

        //    return Ok();
        //}




        public IHttpActionResult Get()
        {
            BikeService bikeService = CreateBikeService();
            var bikes = bikeService.GetBikes();
            return Ok(bikes);
        }
        public IHttpActionResult Post(BikeCreate bike)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBikeService();

            if (!service.CreateBike(bike))
                return InternalServerError();

            return Ok();
        }
        private BikeService CreateBikeService()
        {
            var bikeId = Guid.Parse(User.Identity.GetUserId());
            var bikeService = new BikeService(bikeId);
            return bikeService;
        }
        public IHttpActionResult Get(int id)
        {
            BikeService bikeService = CreateBikeService();
            var bike = bikeService.GetBikeById(id);
            return Ok(bike);
        }
        public IHttpActionResult Put(BikeEdit bike)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBikeService();

            if (!service.UpdateBike(bike))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateBikeService();

            if (!service.DeleteBike(id))
                return InternalServerError();

            return Ok();
        }

    }
}
