using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKTFY.Api.Helpers;
using MKTFY.Models.ViewModels.Listing;
using MKTFY.Services.Services.Interfaces;
using MKTFY.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKTFY.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

            // Get the user Id
            var userId = User.GetId();

            // Have the service create the new Listing
            var result = await _listingService.Create(data, userId);

            //Return as 200 message along with the ListingVM
            return Ok(result);
        }

        // Get a specific Listing by its Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ListingVM>> Get([FromRoute] Guid id)
        {
            // Get the requested Listing entity from the service
            var result = await _listingService.Get(id);

            // Return a 200 message with the ListingVM for the client
            return Ok(result);
        }

        // Get all Listings
        [HttpGet]
        public async Task<ActionResult<List<ListingVM>>> GetAll()
        {
            //Get the Listing entities from the service layer
            var results = await _listingService.GetAll();

            // Return with a 200 response and the ListingVMs
            return Ok(results);
        }

        // Update a Listing
        [HttpPut]
        public async Task<ActionResult<ListingVM>> Update([FromBody] ListingUpdateVM data)
        {
            // Update Listing entity from the service layer
            var result = await _listingService.Update(data);

            // Return a 200 code + the ListingVM to comfirm the update went through properly
            return Ok(result);
        }

        // Delete a Listing
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            // Tell the repository to delete the requested Listing
            await _listingService.Delete(id);

            // Return a 200 response to confirm it has completed
            return Ok();
        }
    }
}
