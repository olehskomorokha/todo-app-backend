using Microsoft.AspNetCore.Mvc;
using TodoApp.Services.Interfaces;
using TodoApp.Services.Models.User;

namespace TodoApp.Controllers.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;

    public UserController(IUserService userService, IJwtService jwtService)
    {
        _jwtService = jwtService;
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _userService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _userService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(AddUserDto userDto)
    {
        await _userService.AddAsync(userDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateUserDto userDto)
    {
        await _userService.UpdateAsync(id, userDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginUserDto userDto)
    {
        var token = await _jwtService.Authenticate(userDto);
        return Ok(token);
    }
}