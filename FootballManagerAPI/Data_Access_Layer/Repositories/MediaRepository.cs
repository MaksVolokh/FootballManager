using FootballManagerAPI.Data;
using FootballManagerDAL.Entities;
using FootballManagerDAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace FootballManagerDAL.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly DataContext _context;
        public MediaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Media>> GetAsync()
        {
            return await _context.Medias.ToListAsync();
        }
        public async Task<Media> GetByIdAsync(int id)
        {
            return await _context.Medias.FindAsync(id);
        }
        public async Task<Media> CreateAsync(Media media)
        {
            _context.Medias.Add(media);
            await _context.SaveChangesAsync();

            return media;
        }

        public async Task<Media> UpdateAsync(Media media)
        {
            _context.Medias.Update(media);
            await _context.SaveChangesAsync();

            return media;
        }
        public async Task DeleteAsync(Media media)
        {
            _context.Medias.Remove(media);
            await _context.SaveChangesAsync();
        }
    }
}
