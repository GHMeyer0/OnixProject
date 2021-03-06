using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnixProject.Api.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public abstract class ApiBaseController : ControllerBase
    {
        private readonly ICollection<string> errors = new List<string>();

        protected ApiBaseController()
        {
            
        }


        protected bool IsValidOperation()
        {
            return errors.Any() is not true;
        }


        protected ActionResult ResponsePutPatch()
        {
            if (IsValidOperation())
            {
                return NoContent();
            }

            return CustomBadRequest();
        }

        private ActionResult CustomBadRequest()
        {
            return BadRequest();
        }

        protected ActionResult<T> ResponseDelete<T>(T item)
        {
            if (IsValidOperation())
            {
                if (item == null)
                    return NoContent();

                return Ok(item);
            }

            return CustomBadRequest();
        }

        protected ActionResult<T> ResponsePost<T>(string action, object route, T result)
        {
            if (IsValidOperation())
            {
                if (result == null)
                    return NoContent();

                return CreatedAtAction(action, route, result);
            }

            return CustomBadRequest();
        }

        protected ActionResult<T> ResponsePost<T>(string action, string controller, object route, T result)
        {
            if (IsValidOperation())
            {
                if (result == null)
                    return NoContent();

                return CreatedAtAction(action, controller, route, result);
            }

            return CustomBadRequest();
        }
        protected ActionResult<IEnumerable<T>> ResponseGet<T>(IEnumerable<T> result)
        {

            if (result == null || !result.Any())
                return NoContent();

            return Ok(result);
        }

        protected ActionResult<T> ResponseGet<T>(T result)
        {
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
            }
        }

        protected ActionResult ModelStateErrorResponseError()
        {
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

    }
}
