using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicianFinder.Domain.Models;
using Musicianfinder_Back.ApplicationCore.Interfaces.Services;
using MusicianFinder_Back.WebAPI.Dto.Request;
using MusicianFinder_Back.WebAPI.Dto.Response;
using MusicianFinder_Back.WebAPI.Token;

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

            _musicianService.Register(musician);

            return Ok(new AuthResponseDto()
            {
                Token = _tokenTool.Generate(musician.Id, musician.Role)
            });
        }
    }
}
