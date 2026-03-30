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
        public IActionResult Register([FromBody] AuthRegisterRequestDto dto)
        {
            Musician musician = new Musician(
                dto.Username, 
                dto.Email,
                dto.Password
            );

            string token = _tokenTool.Generate(new TokenTool.Data()
            {
                MusicianId = musician.Id,
                Role = musician.Role.ToString()
            });

            _musicianService.Register(dto.Username, dto.Email, dto.Password);

            return Ok(new
            {
                Message = "Votre compte a bien été créé !",
                Token = token
            });
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] AuthLoginRequestDto dto)
        {
            var musician = _musicianService.Login(dto.Email, dto.Password);

            string token = _tokenTool.Generate(new TokenTool.Data()
            {
                MusicianId = musician.Id,
                Role = musician.Role.ToString()
            });

            return Ok(new {
                Message = "Vous êtes connecté !",
                Token = token
            });
        }
    }

}
