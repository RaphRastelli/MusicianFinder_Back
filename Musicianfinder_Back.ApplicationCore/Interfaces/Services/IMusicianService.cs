using MusicianFinder.Domain.Models;

namespace Musicianfinder_Back.ApplicationCore.Interfaces.Services
{
    public interface IMusicianService
    {
        Musician Register(Musician musician);
        Musician Login(string email, string password);
    }
}
