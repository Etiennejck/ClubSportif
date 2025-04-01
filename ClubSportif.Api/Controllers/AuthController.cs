using ClubSportif.BLL.Interfaces;
using ClubSportif.DTO.Auth;
using ClubSportif.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClubSportif.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = await _authService.LoginAsync(request.Email, request.Password);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // POST: api/Auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                // Ici, vous pouvez mapper le DTO vers un objet User.
                // Par exemple, vous pouvez créer manuellement l'objet ou utiliser AutoMapper.
                var user = new User
                {
                    Nom = request.Nom,
                    Prenom = request.Prenom,
                    Email = request.Email,
                    Role = request.Role,
                    // Autres propriétés si nécessaire.
                };

                var createdUser = await _authService.RegisterAsync(user, request.Password);
                return Ok(createdUser);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}