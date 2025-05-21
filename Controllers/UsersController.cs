using Microsoft.AspNetCore.Mvc;
using CshBackendDev.Models;
using CshBackendDev.Services;

namespace CshBackendDev.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly UserRepository _repo;

    public UsersController(UserRepository repo)
    {
      _repo = repo;
    }

    // GET: api/users
    [HttpGet]
    public IActionResult GetAllUsers()
    {
      try
      {
        return Ok(_repo.GetAll());
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Internal server error: {ex.Message}");
      }
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
      try
      {
        var user = _repo.GetById(id);
        return user == null ? NotFound($"User with ID {id} not found.") : Ok(user);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Internal server error: {ex.Message}");
      }
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        var createdUser = _repo.Add(user);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Internal server error: {ex.Message}");
      }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        var updated = _repo.Update(id, user);
        return updated ? NoContent() : NotFound($"User with ID {id} not found.");
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Internal server error: {ex.Message}");
      }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
      try
      {
        var deleted = _repo.Delete(id);
        return deleted ? NoContent() : NotFound($"User with ID {id} not found.");
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Internal server error: {ex.Message}");
      }
    }
  }
}
