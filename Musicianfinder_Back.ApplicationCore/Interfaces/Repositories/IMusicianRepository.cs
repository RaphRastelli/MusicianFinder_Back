using MusicianFinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musicianfinder_Back.ApplicationCore.Interfaces.Repositories
{
    public interface IMusicianRepository
    {
        Musician? GetById(long id);
        Musician Insert(Musician data);
        string? GetHashPwd(string email);
        Musician? GetByEmail(string email);

    }
}
