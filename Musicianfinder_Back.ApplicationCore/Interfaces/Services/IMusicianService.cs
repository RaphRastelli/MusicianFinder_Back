using MusicianFinder.Domain.Models;

namespace Musicianfinder_Back.ApplicationCore.Interfaces.Services
{
    public interface IMusicianService
    {
        Musician Login(string email, string password);
        Musician Register(string username, string email, string password);
    }
}
