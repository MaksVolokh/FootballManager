using FootballManagerBLL.Dto.RequestDto.Media;
using FootballManagerBLL.Dto.ResponceDto.Media;
using FootballManagerDAL.Entities;

namespace FootballManagerBLL.Interfaces
{
    public interface IMediaService
    {
        Task<List<MediaResponse>> GetAsync();
        Task<MediaResponse> GetByIdAsync(int id);
        Task<MediaResponse> CreateVideoAsync(CreateVideoRequest videoRequest);
        Task<MediaResponse> CreatePhotoAsync(CreatePhotoRequest photoRequest);
        Task<MediaResponse> UpdateVideoAsync(int id, CreateVideoRequest mediaRequest);
        Task<MediaResponse> UpdatePhotoAsync(int id, CreatePhotoRequest mediaRequest);
        Task<MediaResponse> DeleteMediaAsync(int id);
    }
}
