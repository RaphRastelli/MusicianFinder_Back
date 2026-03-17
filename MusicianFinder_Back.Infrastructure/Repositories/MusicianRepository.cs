using MusicianFinder.Domain.Models;
using Musicianfinder_Back.ApplicationCore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder_Back.Infrastructure.Repositories
{
    public class MusicianRepository : IMusicianRepository
    {
        // Injection DbContext
        private readonly AppDbContext _DbContext;

        public MusicianRepository(AppDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        Musician IMusicianRepository.GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        Musician IMusicianRepository.GetById(long id)
        {
            var result = _DbContext.Musicians.SingleOrDefault(m => m.Id == id);

            if (result == null) { return null; }
            return new Musician(result.Username, result.Email, result.CreatedAt, result.PasswordHash);
        }

        string IMusicianRepository.GetHashPwd(long email)
        {
            return _DbContext.Musicians.SingleOrDefault(m => m.Email == email)?.PasswordHash;
        }

        Musician IMusicianRepository.Insert(Musician data)
        {
            throw new NotImplementedException();
        }

    }
}
