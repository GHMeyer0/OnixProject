using Microsoft.AspNetCore.Mvc;
using OnixProject.Application.Services.Interfaces;
using OnixProject.Application.ViewModels;
using OnixProject.Domain.Searches;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace OnixProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public async Task<IPagedList<UserViewModel>> GetAsync([FromQuery] UserSearch search)
        {
            return await userService.GetAll(search);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}