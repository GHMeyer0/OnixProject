using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnixProject.Application.Services.Interfaces;
using OnixProject.Application.ViewModels;
using OnixProject.Domain.Searches;
using System;
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
        public async Task<ActionResult<IPagedList<UserViewModel>>> GetAsync([FromQuery] UserSearch search)
        {
            return Ok(await userService.GetAll(search));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserViewModel>> GetAsync(Guid id)
        {
            return Ok(await userService.GetById(id));
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

        [HttpPatch("{username}")]
        public async Task<ActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<UserViewModel> model)
        {
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}