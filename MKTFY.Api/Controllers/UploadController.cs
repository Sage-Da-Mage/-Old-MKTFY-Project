using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MKTFY.Models.ViewModels.Upload;
using MKTFY.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKTFY.Api.Controllers
{
    /// <summary>
    /// The controller for uploading images for the MKTFY Project.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {

        private readonly IUploadService _uploadService;
        
        /// <summary>
        /// Adding the contex for the services.
        /// </summary>
        /// <param name="uploadService"></param>
        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        /// <summary>
        /// This endpoint is structured to support uploading multiple images.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<List<UploadResultVM>>> UploadImage()
        {

            // Validate the file types
            var supportedTypes = new[] { ".png", ".gif", ".jpg", ".jpeg" };
            var uploadedExtensions = Request.Form.Files.Select(i => System.IO.Path.GetExtension(i.FileName));
            var mismatchFound = uploadedExtensions.Any(i => !supportedTypes.Contains(i));
            if (mismatchFound)
                return BadRequest(new { message = "At least one uploaded file is not a valid image type"});

            var results = await _uploadService.UploadFiles(Request.Form.Files.ToList());
            return Ok(results);
        }

    }
}
