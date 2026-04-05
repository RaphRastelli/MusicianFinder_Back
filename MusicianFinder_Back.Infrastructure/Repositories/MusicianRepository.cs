using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MusicianFinder.Domain.Enums;
using MusicianFinder.Domain.Models;
using Musicianfinder_Back.ApplicationCore.DTOs;
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
                ?? throw new Exception("Musicien.ne introuvable.");

            musician.SetAbility(ability);
            await _DbContext.SaveChangesAsync();
        }

        // ── Disponibilité ─────────────────────────────────────────────────────────
        public async Task SaveDisponibiliteAsync(long musicianId, AvailabilityLevelEnum availability)
        {
            var musician = await _DbContext.Musicians.FindAsync(musicianId)
                ?? throw new Exception("Musicien.ne introuvable.");

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

        // ── Type de projets ─────────────────────────────────────────────────────────────
        public async Task SaveProjectTypesAsync(long musicianId, List<int> projectTypeIds)
        {
            // Supprime les types existants
            var existing = _DbContext.MusicianProjectTypes
                .Where(pt => pt.MusicianIdFK == musicianId);
            _DbContext.MusicianProjectTypes.RemoveRange(existing);

            // Ajoute les nouveaux via le Static Factory Method
            foreach (var projectTypeId in projectTypeIds)
            {
                _DbContext.MusicianProjectTypes.Add(
                    MusicianProjectType.Create(musicianId, projectTypeId)
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
                ?? throw new Exception("Musicien.ne introuvable.");

            musician.SetDescription(description);
            await _DbContext.SaveChangesAsync();
        }

        // ── profil retourné ────────────────────────────────────────────────────
        public async Task<MusicianProfileAppDto?> GetProfileByIdAsync(long id)
        {
            // On charge le musicien avec toutes ses relations en une seule requête
            var m = await _DbContext.Musicians
                .Include(m => m.MM_MusicianInstruments)
                    .ThenInclude(p => p.Instrument)
                .Include(m => m.MM_MusicianMusicStyles)
                    .ThenInclude(s => s.MusicianStyle)
                .Include(m => m.MM_MusicianLocations)
                    .ThenInclude(l => l.Location)
                .Include(m => m.MM_MusicianProjectTypes)
                    .ThenInclude(pt => pt.ProjectType)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (m is null) return null;

            // Conversion des enums en libellés lisibles
            // Les valeurs correspondent à vos enums AbilityLevelEnum et AvailabilityLevelEnum
            var abilityLabel = m.Ability switch
            {
                AbilityLevelEnum.Debutant => "Débutant",
                AbilityLevelEnum.Intermediaire => "Intermédiaire",
                AbilityLevelEnum.Confirme => "Confirmé",
                AbilityLevelEnum.Professionnnel => "Professionnel",
                _ => null
            };

            var availabilityLabel = m.Availability switch
            {
                AvailabilityLevelEnum.UneFoisSemaineOuPlus => "Une fois par semaine ou plus",
                AvailabilityLevelEnum.DeuxFoisMoisOuPlus => "Deux fois par mois ou plus",
                AvailabilityLevelEnum.UneFoisMoisOuMoins => "Une fois par mois ou moins",
                AvailabilityLevelEnum.Occasionnellement => "Occasionnellement",
                _ => null
            };

            return new MusicianProfileAppDto
            {
                Username = m.Username,

                // Instrument principal — celui où IsMainInstrument = true
                InstrumentPrincipal = m.MM_MusicianInstruments
                    .FirstOrDefault(p => p.IsMainInstrument)
                    ?.Instrument.InstrumentName,

                Ability = abilityLabel,

                // Instruments secondaires — ceux où IsMainInstrument = false
                InstrumentsSecondaires = m.MM_MusicianInstruments
                    .Where(p => !p.IsMainInstrument)
                    .Select(p => p.Instrument.InstrumentName)
                    .ToList(),

                // Style principal — celui où IsMainStyle = true
                StylePrincipal = m.MM_MusicianMusicStyles
                    .FirstOrDefault(s => s.IsMainStyle)
                    ?.MusicianStyle.StyleName,

                // Styles secondaires — ceux où IsMainStyle = false
                StylesSecondaires = m.MM_MusicianMusicStyles
                    .Where(s => !s.IsMainStyle)
                    .Select(s => s.MusicianStyle.StyleName)
                    .ToList(),

                Locations = m.MM_MusicianLocations
                    .Select(l => l.Location.LocationName)
                    .ToList(),

                // ← Conversion des ProjectTypes
                ProjectTypes = m.MM_MusicianProjectTypes
            .Select(pt => pt.ProjectType.TypeName switch
            {
                "LongTermeSansGarantie" => "Projet à long terme sans garantie financière",
                "LongTermAvecGarantie" => "Projet à long terme avec garantie financière",
                "PonctuelSansGarantie" => "Projet ponctuel sans garantie financière",
                "PonctuelAvecGarantie" => "Projet ponctuel avec garantie financière",
                "Cours" => "Cours de mon instrument",
                _ => pt.ProjectType.TypeName
            })
            .ToList(),

                Availability = availabilityLabel,
                Description = m.Description,
                Email = m.Email
            };
        }
    }
}
