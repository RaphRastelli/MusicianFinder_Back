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

        // Implementation repository - TODO ctor Musician
        /*public Musician GetById(long id)
        {
            var result = _DbContext.Musicians.SingleOrDefault(m => m.Id == id);

            if (result == null) { return null}
            return new Musician(result.Id, result.Username, result.Email);
        }*/
    }
}
