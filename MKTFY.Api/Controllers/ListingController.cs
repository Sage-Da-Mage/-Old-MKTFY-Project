using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKTFY.Models.ViewModels.Listing;
using MKTFY.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKTFY.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        // Set up dependency injection for IListingService
        private readonly IListingService _listingService;
        public ListingController(IListingService listingService)
        {
            _listingService = listingService;
        }

        // Create a new Listing
        [HttpPost]
        public async Task<ActionResult<ListingVM>> Create([FromBody] ListingAddVM data)
        {
            try
            {
                // Have the service create the new Listing
                var result = await _listingService.Create(data);

                //Return as 200 message along with the ListingVM
                return Ok(result);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unable to contact the data" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get a specific Listing by its Id
        [HttpGet]
        public async Task<ActionResult<ListingVM>> Get([FromRoute] Guid id)
        {
            try
            {
                // Get the requested Listing entity from the service
                var result = await _listingService.Get(id);

                // Return a 200 message with the ListingVM for the client
                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "Unable to rerieve the requested listing:" });
            }
        }

        // Get all Listings
        [HttpGet]
        public async Task<ActionResult<List<ListingVM>>> GetAll()
        {
            try
            {
                //Get the Listing entities from the service layer
                var results = await _listingService.GetAll();

                // Return with a 200 response and the ListingVMs
                return Ok(results);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        // Update a Listing
        [HttpPut]
        public async Task<ActionResult<ListingVM>> Update([FromBody] ListingUpdateVM data)
        {
            try
            {
                // Update Listing entity from the service layer
                var result = await _listingService.Update(data);

                // Return a 200 code + the ListingVM to comfirm the update went through properly
                return Ok(result);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unable to contact the database" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete a Listing
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                // Tell the repository to delete the requested Listing
                await _listingService.Delete(id);

                // Return a 200 response to confirm it has completed
                return Ok();
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unable to contact the database" });
            }
            catch
            {
                return BadRequest(new { message = "Unable to delete the requesed listing" });
            }
        }
    }
}
