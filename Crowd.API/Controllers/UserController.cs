using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Crowd.DAL.Interfaces;
using Crowd.DAL.Entities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Crowd.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        IRepository<User> userrepoisitory;
        public UserController(IRepository<User> userrepoisitory)
        {
            this.userrepoisitory = userrepoisitory;
        }
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return userrepoisitory.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = userrepoisitory.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        [HttpPost]
        public IActionResult Add([FromBody] User item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            userrepoisitory.Add(item);
            return CreatedAtRoute("GetUser", new { Controller = "User", id = item.Id }, item);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userrepoisitory.Remove(id);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = userrepoisitory.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            userrepoisitory.Update(item);
            return new NoContentResult();
        }
    }
}
