using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicianFinder.Domain.Models;
using Musicianfinder_Back.ApplicationCore.Interfaces.Services;
using MusicianFinder_Back.WebAPI.Dto.Request;
using MusicianFinder_Back.WebAPI.Dto.Response;
using MusicianFinder_Back.WebAPI.Token;
using System.Data;

namespace MusicianFinder_Back.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMusicianService _musicianService;
        private readonly TokenTool _tokenTool;

        public AuthController(IMusicianService musicianService, TokenTool tokenTool)
        {
            _musicianService = musicianService;
            _tokenTool = tokenTool;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AuthRegisterRequestDto dto)
        {
            // 1. Le service gère le hachage et l'insertion — il retourne le Musician inséré
            Musician musician = await _musicianService.Register(
                dto.Username,
                dto.Email,
                dto.Password
            );

            // 2. Le token est généré APRÈS l'insertion — on a le vrai Id
            string token = _tokenTool.Generate(new TokenTool.Data()
            {
                MusicianId = musician.Id,
                Role = musician.Role.ToString()
            });

            // 3. La réponse correspond exactement à ce qu'attend le frontend
            return Ok(new
            {
                token = token,
                username = musician.Username,
                role = musician.Role.ToString()
            });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AuthLoginRequestDto dto)
        {
            var musician = await _musicianService.Login(dto.Email, dto.Password);

            string token = _tokenTool.Generate(new TokenTool.Data()
            {
                MusicianId = musician.Id,
                Role = musician.Role.ToString()
            });

            return Ok(new {
                token = token,
                username = musician.Username,
                role = musician.Role.ToString()
            });
        }
    }

}
