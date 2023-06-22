using FootballManagerBLL.Dto.RequestDto.Media;
using FootballManagerBLL.Dto.ResponceDto.Media;
using FootballManagerDAL.Entities;

namespace FootballManagerBLL.Dto.ConvertorDto.MediaConvertor
{
    public static class MediaConverter
    {
        public static MediaResponse ConvertToResponse(Media media)
        {
            return new MediaResponse
            {
                Id = media.Id,
                Title = media.Title,
                Description = media.Description,
                VideoUrl = media.VideoUrl,
                PhotoUrl = media.PhotoUrl
            };
        }

        public static Media ConvertToVideoEntity(CreateVideoRequest videoRequest)
        {
            return new Media
            {
                Title = videoRequest.Title,
                Description = videoRequest.Description,
                VideoUrl = videoRequest.VideoUrl
            };
        }

        public static Media ConvertToPhotoEntity(CreatePhotoRequest photoRequest)
        {
            return new Media
            {
                Title = photoRequest.Title,
                Description = photoRequest.Description,
                PhotoUrl = photoRequest.PhotoUrl
            };
        }

        public static void UpdateEntityVideoFromRequest(Media media, CreateVideoRequest mediaRequest)
        {
            media.Title = mediaRequest.Title;
            media.Description = mediaRequest.Description;
            media.VideoUrl = mediaRequest.VideoUrl;
        }

        public static void UpdateEntityPhotoFromRequest(Media media, CreatePhotoRequest mediaRequest)
        {
            media.Title = mediaRequest.Title;
            media.Description = mediaRequest.Description;
            media.PhotoUrl = mediaRequest.PhotoUrl;
        }
    }
}
