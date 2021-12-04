using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MKTFY.Models.ViewModels.Upload;
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

        /// <summary>
        /// This endpoint is structured to support uploading multiple images.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<List<UploadResultVM>>> UploadImage()
        {
            var results = new List<UploadResultVM>();

            // Iterate over all the files
            foreach(var file in Request.Form.Files){
                
                // Build the response object
                results.Add(new UploadResultVM 
                {
                    FileName = file.FileName
                });
            }
            return Ok(results);

        }

    }
}
