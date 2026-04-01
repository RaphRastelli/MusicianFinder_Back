using MusicianFinder.Domain.Enums;
using MusicianFinder.Domain.Models;
using Musicianfinder_Back.ApplicationCore.Interfaces.Repositories;
using Musicianfinder_Back.ApplicationCore.Interfaces.Services;
using Soenneker.Hashing.Argon2;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Musicianfinder_Back.ApplicationCore.Services
{
    public class MusicianService : IMusicianService
    {
        private readonly IMusicianRepository _musicianRepository;

        public MusicianService(IMusicianRepository musicianRepository)
        {
            _musicianRepository = musicianRepository;
        }

        public async Task<Musician> Login(string email, string password)
        {
            string? hashPwd = _musicianRepository.GetHashPwd(email);

            if (hashPwd is null)
            {
                throw new Exception("Les informations d'identification sont invalides.");
            }

            bool isValid = await Argon2HashingUtil.Verify(password, hashPwd);

            if (!isValid)
            {
                // Le mot de passe est invalide !
                throw new Exception("Les informations d'identification sont invalides.");
            }

            Musician? musician = _musicianRepository.GetByEmail(email);
            if (musician is null)
                throw new Exception("Les informations d'identification sont invalides.");

            return musician;
        }

        public async Task<Musician> Register(string username, string email, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Password manquant.");
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Username manquant");
            }

            if (_musicianRepository.GetByEmail(email) is not null)
                throw new Exception("Cet e-mail existe déjà");


            // Hashage password
            string hash = await Argon2HashingUtil.Hash(password);

            // Recréation Musician avec pswd hashé
            Musician musicianToInsert = new Musician(username, email, hash);

            // TODO : envoi du mail de bienvenue (mailer)

            // Insertion et retour du musicien avec son vrai Id
            return _musicianRepository.Insert(musicianToInsert);
        }

        public async Task SaveInstrumentPrincipal(long musicianId, int instrumentId)
        {
            // Validation métier — l'id doit être valide
            if (instrumentId <= 0)
                throw new ArgumentException("Instrument invalide.");

            await _musicianRepository.SaveInstrumentPrincipalAsync(musicianId, instrumentId);
        }

        public async Task SaveInstrumentsSecondaires(long musicianId, List<int> instrumentIds)
        {
            // Validation métier — max 3 instruments secondaires
            if (instrumentIds.Count > 3)
                throw new ArgumentException("Maximum 3 instruments secondaires.");

            await _musicianRepository.SaveInstrumentsSecondairesAsync(musicianId, instrumentIds);
        }

        public async Task SaveNiveau(long musicianId, AbilityLevelEnum ability)
        {
            await _musicianRepository.SaveNiveauAsync(musicianId, ability);
        }

        public async Task SaveDisponibilite(long musicianId, AvailabilityLevelEnum availability)
        {
            await _musicianRepository.SaveDisponibiliteAsync(musicianId, availability);
        }

        public async Task SaveLocations(long musicianId, List<int> locationIds)
        {
            // Validation métier — au moins une location requise
            if (locationIds.Count == 0)
                throw new ArgumentException("Au moins une localisation est requise.");

            await _musicianRepository.SaveLocationsAsync(musicianId, locationIds);
        }

        public async Task SaveStylePrincipal(long musicianId, int styleId)
        {
            if (styleId <= 0)
                throw new ArgumentException("Style invalide.");

            await _musicianRepository.SaveStylePrincipalAsync(musicianId, styleId);
        }

        public async Task SaveStylesSecondaires(long musicianId, List<int> styleIds)
        {
            await _musicianRepository.SaveStylesSecondairesAsync(musicianId, styleIds);
        }
    }
}
