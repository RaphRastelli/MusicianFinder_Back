using MusicianFinder.Domain.Models;

namespace Musicianfinder_Back.ApplicationCore.Interfaces.Services
{
    public interface IMusicianService
    {
        Task<Musician> Login(string email, string password);
        Task<Musician> Register(string username, string email, string password);
    }
}
