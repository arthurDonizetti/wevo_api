using System.Net;
using System;
using System.Threading.Tasks;
using App.Domain.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Models;
using App.Domain.Models.User;

namespace Api.Application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private IUserService _service;
    public UsersController(IUserService service)
    {
      this._service = service;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
      if (ModelState.IsValid == false)
        return BadRequest(ModelState);

      try
      {
        return Ok(await this._service.GetAll());
      }
      catch (ArgumentException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [HttpGet]
    [Route("{id}", Name = "GetWithId")]
    public async Task<ActionResult> Get(Guid Id)
    {
      if (ModelState.IsValid == false)
        return BadRequest(ModelState);

      try
      {
        return Ok(await this._service.Get(Id));
      }
      catch (ArgumentException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] User user)
    {
      if (ModelState.IsValid == false)
        return BadRequest(ModelState);

      try
      {
        var entry = await this._service.Post(user);
        if (entry != null)
          return Created(new Uri(Url.Link("GetWithId", new { id = entry.Id })), entry);
        else
          return BadRequest();
      }
      catch (ArgumentException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] User user)
    {
      if (ModelState.IsValid == false)
        return BadRequest(ModelState);

      try
      {
        var entry = await this._service.Put(user);
        if (entry != null)
          return Ok(entry);
        else
          return BadRequest();
      }
      catch (ArgumentException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [HttpDelete]
    [Route("{id}", Name = "DeleteWithId")]
    public async Task<ActionResult> Delete(Guid Id)
    {
      if (ModelState.IsValid == false)
        return BadRequest(ModelState);

      try
      {
        return Ok(await this._service.Delete(Id));
      }
      catch (ArgumentException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }
  }
}
