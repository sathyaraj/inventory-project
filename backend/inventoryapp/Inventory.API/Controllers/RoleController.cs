using Inventory.Application.Interface;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleRepository _repo;

    public RoleController(IRoleRepository repo)
    {
        _repo = repo;
    }

    // CREATE ROLE
    [HttpPost("create")]
    public async Task<IActionResult> CreateRole([FromBody] Role role)
    {
        try
        {
            var result = await _repo.CreateRoleAsync(role);

            return Ok(new
            {
                message = "Role Created Successfully",
                data = result
            });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET ALL ROLES
    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        var result = await _repo.GetAllRolesAsync();

        return Ok(result);
    }
}