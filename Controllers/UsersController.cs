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
      return Ok(_repo.GetAll());
    }

    // GET: api/users/{id}
    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
      var user = _repo.GetById(id);
      return user == null ? NotFound() : Ok(user);
    }

    // POST: api/users
    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
      var createdUser = _repo.Add(user);
      return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }

    // PUT: api/users/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
      var updated = _repo.Update(id, user);
      return updated ? NoContent() : NotFound();
    }

    // DELETE: api/users/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
      var deleted = _repo.Delete(id);
      return deleted ? NoContent() : NotFound();
    }
  }
}
