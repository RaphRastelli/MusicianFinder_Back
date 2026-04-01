using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MusicianFinder.Domain.Enums;
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

        // Méthodes d'accès aux données
        public Musician? GetByEmail(string email)
        {
            return _DbContext.Musicians.SingleOrDefault(m => m.Email == email);
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

            return element.Entity;
        }

        // ── Instrument principal ──────────────────────────────────────────────────
        public async Task SaveInstrumentPrincipalAsync(long musicianId, int instrumentId)
        {
            var existing = _DbContext.MusicianPlaysInstruments
                .Where(p => p.MusicianIdFK == musicianId && p.IsMainInstrument);
            _DbContext.MusicianPlaysInstruments.RemoveRange(existing);

            // On passe par le static factory method — plus de new direct
            _DbContext.MusicianPlaysInstruments.Add(
                MusicianPlaysInstrument.Create(musicianId, instrumentId, isMainInstrument: true)
            );

            await _DbContext.SaveChangesAsync();
        }

        // ── Instruments secondaires ───────────────────────────────────────────────
        public async Task SaveInstrumentsSecondairesAsync(long musicianId, List<int> instrumentIds)
        {
            var existing = _DbContext.MusicianPlaysInstruments
                .Where(p => p.MusicianIdFK == musicianId && !p.IsMainInstrument);
            _DbContext.MusicianPlaysInstruments.RemoveRange(existing);

            foreach (var id in instrumentIds)
            {
                _DbContext.MusicianPlaysInstruments.Add(
                    MusicianPlaysInstrument.Create(musicianId, id, isMainInstrument: false)
                );
            }

            await _DbContext.SaveChangesAsync();
        }

        // ── Niveau ────────────────────────────────────────────────────────────────
        public async Task SaveNiveauAsync(long musicianId, AbilityLevelEnum ability)
        {
            var musician = await _DbContext.Musicians.FindAsync(musicianId)
                ?? throw new Exception("Musicien introuvable.");

            musician.SetAbility(ability);
            await _DbContext.SaveChangesAsync();
        }

        // ── Disponibilité ─────────────────────────────────────────────────────────
        public async Task SaveDisponibiliteAsync(long musicianId, AvailabilityLevelEnum availability)
        {
            var musician = await _DbContext.Musicians.FindAsync(musicianId)
                ?? throw new Exception("Musicien introuvable.");

            musician.SetAvailability(availability);
            await _DbContext.SaveChangesAsync();
        }

        // ── Locations ─────────────────────────────────────────────────────────────
        public async Task SaveLocationsAsync(long musicianId, List<int> locationIds)
        {
            var existing = _DbContext.MusicianLocations
                .Where(ml => ml.MusicianIdFK == musicianId);
            _DbContext.MusicianLocations.RemoveRange(existing);

            foreach (var locationId in locationIds)
            {
                _DbContext.MusicianLocations.Add(
                    MusicianLocation.Create(musicianId, locationId)
                );
            }

            await _DbContext.SaveChangesAsync();
        }

        // ── Style principal ───────────────────────────────────────────────────────
        public async Task SaveStylePrincipalAsync(long musicianId, int styleId)
        {
            var existing = _DbContext.MusicianLikesStyles
                .Where(s => s.MusicianIdFK == musicianId && s.IsMainStyle);
            _DbContext.MusicianLikesStyles.RemoveRange(existing);

            _DbContext.MusicianLikesStyles.Add(
                MusicianLikesStyle.Create(musicianId, styleId, isMainStyle: true)
            );

            await _DbContext.SaveChangesAsync();
        }

        // ── Styles secondaires ────────────────────────────────────────────────────
        public async Task SaveStylesSecondairesAsync(long musicianId, List<int> styleIds)
        {
            var existing = _DbContext.MusicianLikesStyles
                .Where(s => s.MusicianIdFK == musicianId && !s.IsMainStyle);
            _DbContext.MusicianLikesStyles.RemoveRange(existing);

            foreach (var styleId in styleIds)
            {
                _DbContext.MusicianLikesStyles.Add(
                    MusicianLikesStyle.Create(musicianId, styleId, isMainStyle: false)
                );
            }

            await _DbContext.SaveChangesAsync();
        }

        // ── Description ────────────────────────────────────────────────────
        public async Task SaveDescriptionAsync(long musicianId, string? description)
        {
            var musician = await _DbContext.Musicians.FindAsync(musicianId)
                ?? throw new Exception("Musicien introuvable.");

            musician.SetDescription(description);
            await _DbContext.SaveChangesAsync();
        }
    }
}
