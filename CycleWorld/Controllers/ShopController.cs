using CycleWorld.Data;
using CycleWorld.Models;
using CycleWorld.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CycleWorld.WebAPI.Controllers
{
    [Authorize]
    public class ShopController : ApiController
    {
        public IHttpActionResult Get()
        {
            ShopService shopService = CreateShopService();
            var shops = shopService.GetShop();
            return Ok(shops);
        }
        public IHttpActionResult Post(ShopCreate shop)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShopService();

            if (!service.CreateShop(shop))
                return InternalServerError();

            return Ok();
        }
        private ShopService CreateShopService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var shopService = new ShopService(userId);
            return shopService;
        }
        public IHttpActionResult Get(int id)
        {
            ShopService shopService = CreateShopService();
            var shop = shopService.GetShopById(id);
            return Ok(shop);
        }
        public IHttpActionResult Put(ShopEdit shop)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShopService();

            if (!service.UpdateShop(shop))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateShopService();

            if (!service.DeleteShop(id))
                return InternalServerError();

            return Ok();
        }
    }
}
