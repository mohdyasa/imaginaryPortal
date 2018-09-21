using imaginaryPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using imaginaryPortal.ViewModel;
namespace imaginaryPortal.Controllers.api
{
    public class masterController : ApiController
    {
        private imaginaryDbContext _context;

        public masterController()
        {
            _context = new imaginaryDbContext();
        }
        [HttpPost]
        public IHttpActionResult addUser(userViewModel u)
        {
            if(ModelState.IsValid)
            {
                //_context.Users.Add(u);
               // _context.SaveChanges();
                ModelState.Clear();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }
        [HttpGet]
        public IEnumerable<User> loadUsers()
        {
            return _context.Users.ToList();
        }
    }
}
