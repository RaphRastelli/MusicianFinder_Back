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

        public Musician Register(string username, string email, string password)
        {
            if (string.IsNullOrEmpty(password))
            { 
                throw new ArgumentNullException("Password manquant");
            }

            if (string.IsNullOrEmpty(username)) 
            { 
                throw new ArgumentNullException("Username manquant");
            }

            if (_musicianRepository.GetByEmail(email) is not null)
                throw new Exception("Cet e-mail existe déjà");


            // Hashage password
            string hash = Argon2HashingUtil.Hash(password).Result;

            // Recréation Musician avec pswd hashé
            Musician musicianToInsert = new Musician(
                username,
                email,
                hash
                );

            // Création du compte dans DB via repository
            Musician musicianInserted = _musicianRepository.Insert(musicianToInsert);

            // Envoi du compte créer
            return musicianInserted;
        }
    }
}
