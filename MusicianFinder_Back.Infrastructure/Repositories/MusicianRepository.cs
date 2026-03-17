using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public Musician? GetByEmail(string email)
        {
            var result = _DbContext.Musicians.SingleOrDefault(m => m.Email == email);

            return new Musician(result.Id, result.Username, result.Email, result.CreatedAt, result.Description, result.Role, result.Ability, result.Availability, result.BgColor, result.FontFamily, result.TextColor, result.PasswordHash);
        }

        public Musician? GetById(long id)
        {
            var result = _DbContext.Musicians.SingleOrDefault(m => m.Id == id);

            if (result == null) { return null; }
            return new Musician(result.Username, result.Email, result.PasswordHash);
        }

        public string? GetHashPwd(string email)
        {
            return _DbContext.Musicians.SingleOrDefault(m => m.Email == email)?.PasswordHash;
        }

        public Musician Insert(Musician musician)
        {
            EntityEntry<Musician> element = _DbContext.Musicians.Add(musician);
            _DbContext.SaveChanges();

            var result = element.Entity;

            return new Musician(musician.Id, musician.Username, musician.PasswordHash);
        }

    }
}
