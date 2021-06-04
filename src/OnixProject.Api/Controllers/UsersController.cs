using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnixProject.Application.Services.Interfaces;
using OnixProject.Application.ViewModels;
using OnixProject.Domain.Searches;
using System;
using System.Threading.Tasks;

namespace OnixProject.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ApiBaseController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PagedList<UserViewModel>>> Get([FromQuery] UserSearch search)
        {
            return Ok(await userService.GetAll(search));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserViewModel>> GetById(Guid id)
        {
            return Ok(await userService.GetById(id));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Post([FromBody] CreateUserRequest createUserRequest)
        {
            var newUser = await userService.Create(createUserRequest);
            return ResponsePost(nameof(GetById), new { id = newUser.Id }, newUser);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> PutAsync(Guid id, [FromBody] UserViewModel userViewModel)
        {
            await userService.Update(userViewModel);
            return ResponsePutPatch();
        }

        [HttpPatch("{id:guid}")]
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