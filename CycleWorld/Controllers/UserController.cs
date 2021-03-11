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

namespace CycleWorld.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        public IHttpActionResult Get()
        {
            UserService userService = CreateUserService();
            var users = userService.GetUsers();
            return Ok(users);
        }
        public IHttpActionResult Post(UserCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.CreateUser(user))
                return InternalServerError();

            return Ok();
        }
        private UserService CreateUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userService = new UserService(userId);
            return userService;
        }
        public IHttpActionResult GetById(int id)
        {
            UserService userService = CreateUserService();
            var user = userService.GetUserById(id);
            return Ok(user);
        }
        public IHttpActionResult Put(UserEdit user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.UpdateUser(user))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateUserService();

            if (!service.DeleteUser(id))
                return InternalServerError();

            return Ok();
        }
        
    }
}
