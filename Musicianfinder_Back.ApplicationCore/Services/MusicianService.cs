using MusicianFinder.Domain.Models;
using Musicianfinder_Back.ApplicationCore.Interfaces.Repositories;
using Musicianfinder_Back.ApplicationCore.Interfaces.Services;
using Soenneker.Hashing.Argon2;
using System;
using System.Collections.Generic;
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


        public Musician Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Musician Register(Musician musician)
        {
            if (string.IsNullOrEmpty(musician.PasswordHash))
            { 
                throw new ArgumentNullException("Password manquant");
            }


            // Hashage password
            string hash = Argon2HashingUtil.Hash(musician.PasswordHash).Result;

            // Recréation Musician avec pswd hashé
            Musician musicianToInsert = new Musician(
                musician.Username,
                musician.Email,
                musician.CreatedAt,
                hash
                );

            // Création du compte dans DB via repository
            Musician musicianInserted = _musicianRepository.Insert(musicianToInsert);

            // Envoi du compte créer
            return musicianInserted;
        }
    }
}
