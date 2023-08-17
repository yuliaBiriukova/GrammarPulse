using AutoMapper;
using GrammarPulse.BLL.Enums;
using GrammarPulse.BLL.Models;
using GrammarPulse.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GrammarPulse.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult> Login()
    {
        var userEmail = User.FindFirst(ClaimTypes.Name)?.Value;
        if (userEmail is not null)
        {
            var user = await _userService.GetUserByEmailAsync(userEmail);
            if (user is null)
            {
                var id = await _userService.AddUserAsync(new UserDto(userEmail, UserRole.Student));
                user = await _userService.GetUserByIdAsync(id);
            }
            return Ok(user?.Role);
        }
        return Ok();
    }
}