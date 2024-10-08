﻿using Microsoft.AspNetCore.Mvc;
using PolyFlora.Application.DTOs.Auth;
using PolyFlora.Application.Services.Domain;

namespace PolyFlora.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(AuthRequest login)
        {
            var result = await _authService.Login(login.email, login.password);
            if (!result.IsLogedIn)
            {
                return BadRequest("Failed to login");
            }
            return Ok(new AuthResponse(result.JwtToken!,result.RefreshToken!));
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Registration(AuthRequest login)
        {
            await _authService.Registration(login.email, login.password);
            return Ok();
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenModel model)
        {
            var data = await _authService.RefreshToken(model);
            if (!data.IsLogedIn)
            {
                return BadRequest("Failed to update access token");
            }
            return Ok(new AuthResponse(data.JwtToken!, data.RefreshToken!));
        }
    }
}
