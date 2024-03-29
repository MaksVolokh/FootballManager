﻿using FootballManagerBLL.Dto.RequestDto.Media;
using FootballManagerBLL.Dto.ResponceDto.Media;
using FootballManagerBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Localization;

namespace FootballManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : Controller
    {
        private readonly IMediaService _service;
        private readonly IStringLocalizer<MediaController> _localizer;
        public MediaController(IMediaService service, IStringLocalizer<MediaController> localizer)
        {
            _service = service;
            _localizer = localizer;
        }

        [HttpGet]
        public async Task<ActionResult<List<MediaResponse>>> GetAsync()
        {
            var medias = await _service.GetAsync();

            if (medias.Count == 0)
            {
                return NotFound(_localizer["Medias not found!"]);
            }

            return Ok(medias);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MediaResponse>> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest(_localizer["Invalid Id!"]);
            }

            var media = await _service.GetByIdAsync(id);

            if (media == null)
            {
                return NotFound(_localizer["Media not found!"]);
            }

            return Ok(media);
        }

        [HttpPost("AddVideo")]
        public async Task<ActionResult<MediaResponse>> CreateVideoAsync([FromBody] CreateVideoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedVideo = await _service.CreateVideoAsync(request);

            if (addedVideo == null)
            {
                return BadRequest(_localizer["Failed to add video!"]);
            }

            return Ok(addedVideo);
        }

        [HttpPost("AddPhoto")]
        public async Task<ActionResult<MediaResponse>> CreatePhotoAsync([FromBody] CreatePhotoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedPhoto = await _service.CreatePhotoAsync(request);

            if (addedPhoto == null)
            {
                return BadRequest(_localizer["Failed to add photo!"]);
            }

            return Ok(addedPhoto);
        }

        [HttpPut("UpdateVideo")]
        public async Task<ActionResult> UpdateVideoAsync(int id, [FromBody] CreateVideoRequest request)
        {
            if (id < 0)
            {
                return BadRequest(_localizer["Invalid Id!"]);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var media = await _service.UpdateVideoAsync(id, request);

            if (media == null)
            {
                return NotFound(_localizer["Video not found!"]);
            }

            return Ok(media);
        }

        [HttpPut("UpdatePhoto")]
        public async Task<ActionResult> UpdatePhotoAsync(int id, [FromBody] CreatePhotoRequest request)
        {
            if (id < 0)
            {
                return BadRequest(_localizer["Invalid Id!"]);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var media = await _service.UpdatePhotoAsync(id, request);

            if (media == null)
            {
                return NotFound(_localizer["Photo not found!"]);
            }

            return Ok(media);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteMediaAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest(_localizer["Invalid Id!"]);
            }

            var media = await _service.DeleteMediaAsync(id);

            if (media == null)
            {
                return NotFound(_localizer["Media not found!"]);
            }

            return NoContent();
        }
    }
}
