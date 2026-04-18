using Musicianfinder_Back.ApplicationCore.DTOs;

namespace Musicianfinder_Back.ApplicationCore.Interfaces.Repositories
{
    public interface ISearchRepository
    {
        // Retourne les musiciens jouant l'instrument cherché
        // avec toutes leurs relations chargées pour le calcul du score
        Task<List<MusicianSearchAppDto>> GetMusiciansByInstrumentAsync(int instrumentId, int locationId);
    }
}
