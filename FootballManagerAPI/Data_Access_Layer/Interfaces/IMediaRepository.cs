using FootballManagerDAL.Entities;

namespace FootballManagerDAL.Interfaces
{
    public interface IMediaRepository
    {
        Task<List<Media>> GetAsync();
        Task<Media> GetByIdAsync(int id);
        Task<Media> CreateAsync(Media media);
        Task<Media> UpdateAsync(Media media);
        Task DeleteAsync(Media media);
    }
}
