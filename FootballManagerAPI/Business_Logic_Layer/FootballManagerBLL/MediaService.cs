using FootballManagerBLL.Dto.ConvertorDto.MediaConvertor;
using FootballManagerBLL.Dto.RequestDto.Media;
using FootballManagerBLL.Dto.ResponceDto.Media;
using FootballManagerBLL.Interfaces;
using FootballManagerDAL.Interfaces;

namespace FootballManagerBLL.FootballManagerBLL
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;
        public MediaService(IMediaRepository mediaRepository) 
        {
            _mediaRepository = mediaRepository;
        }

        public async Task<List<MediaResponse>> GetAsync()
        {
            var medias = await _mediaRepository.GetAsync();

            return medias.Select(MediaConverter.ConvertToResponse).ToList();
        }

        public async Task<MediaResponse> GetByIdAsync(int id)
        {
            var media = await _mediaRepository.GetByIdAsync(id);

            if (media == null)
            {
                return null;
            }

            return MediaConverter.ConvertToResponse(media);
        }

        public async Task<MediaResponse> CreateVideoAsync(CreateVideoRequest videoRequest)
        {
            var media = MediaConverter.ConvertToVideoEntity(videoRequest);

            var addedMedia = await _mediaRepository.CreateAsync(media);

            return MediaConverter.ConvertToResponse(addedMedia);
        }

        public async Task<MediaResponse> CreatePhotoAsync(CreatePhotoRequest photoRequest)
        {
            var media = MediaConverter.ConvertToPhotoEntity(photoRequest);

            var addedMedia = await _mediaRepository.CreateAsync(media);

            return MediaConverter.ConvertToResponse(addedMedia);
        }

        public async Task<MediaResponse> UpdateVideoAsync(int id, CreateVideoRequest mediaRequest)
        {
            var media = await _mediaRepository.GetByIdAsync(id);

            if (media == null)
            {
                return null;
            }

            MediaConverter.UpdateEntityVideoFromRequest(media, mediaRequest);

            var updatedMedia = await _mediaRepository.UpdateAsync(media);

            return MediaConverter.ConvertToResponse(updatedMedia);
        }

        public async Task<MediaResponse> UpdatePhotoAsync(int id, CreatePhotoRequest mediaRequest)
        {
            var media = await _mediaRepository.GetByIdAsync(id);

            if (media == null)
            {
                return null;
            }

            MediaConverter.UpdateEntityPhotoFromRequest(media, mediaRequest);

            var updatedMedia = await _mediaRepository.UpdateAsync(media);

            return MediaConverter.ConvertToResponse(updatedMedia);
        }

        public async Task<MediaResponse> DeleteMediaAsync(int id)
        {
            var media = await _mediaRepository.GetByIdAsync(id);

            if (media == null)
            {
                return null;
            }

            await _mediaRepository.DeleteAsync(media);

            return MediaConverter.ConvertToResponse(media);
        }
    }
}
