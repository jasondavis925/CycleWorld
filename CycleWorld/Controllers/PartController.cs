using CycleWorld.Data;
using CycleWorld.Models;
using CycleWorld.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace CycleWorld.WebAPI.Controllers
{
    [Authorize]
    public class PartController : ApiController
    {
        public IHttpActionResult Get()
        {
            PartService partService = CreatePartService();
            var parts = partService.GetParts();
            return Ok(parts);
        }
        public IHttpActionResult Post(PartCreate part)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePartService();

            if (!service.CreatePart(part))
                return InternalServerError();

            return Ok();
        }

        private PartService CreatePartService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var partService = new PartService(userId);
            return partService;
        }
        public IHttpActionResult Get(int id)
        {
            PartService partService = CreatePartService();
            var part = partService.GetPartById(id);
            return Ok(part);
        }
        public IHttpActionResult Put(PartEdit part)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePartService();

            if (!service.UpdatePart(part))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePartService();

            if (!service.DeletePart(id))
                return InternalServerError();

            return Ok();
        }
    }
}
