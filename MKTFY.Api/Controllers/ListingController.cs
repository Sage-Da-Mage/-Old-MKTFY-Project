using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKTFY.Api.Helpers;
using MKTFY.Models.ViewModels.Listing;
using MKTFY.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKTFY.Api.Controllers
{
    /// <summary>
    /// The Controller for handling Listings and related code.
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ListingController : ControllerBase
    {
        // Set up dependency injection for IListingService
        private readonly IListingService _listingService;
        
        /// <summary>
        /// The Constructor that takes in a IListingService
        /// </summary>
        /// <param name="listingService"></param>
        public ListingController(IListingService listingService)
        {
            _listingService = listingService;
        }


        /// <summary>
        /// Creates a Listing from inputed data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get a Listing by it's Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ListingVM>> Get([FromRoute] Guid id)
        {
            // Get the requested Listing entity from the service
            var result = await _listingService.Get(id);

            // Return a 200 message with the ListingVM for the client
            return Ok(result);
        }

        /// <summary>
        /// Gets all Listings in the database. 
        /// </summary>
        /// <response code="200">Listing Found</response>
        /// <response code="401">Not Currently Logged in || Auth error</response>
        /// <response code="500">Internal Server Issue. E.g. connectivity, database, etc.</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ListingVM>>> GetAll()
        {
            //Get the Listing entities from the service layer
            var results = await _listingService.GetAll();

            // Return with a 200 response and the ListingVMs
            return Ok(results);
        }

        /// <summary>
        /// Update a Listing using inputted data, excluding non-updatable properties
        /// like id.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ListingVM>> Update([FromBody] ListingUpdateVM data)
        {
            // Update Listing entity from the service layer
            var result = await _listingService.Update(data);

            // Return a 200 code + the ListingVM to comfirm the update went through properly
            return Ok(result);
        }

        /// <summary>
        /// Delete a listing from the database (determined by Id).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            // Tell the repository to delete the requested Listing
            await _listingService.Delete(id);

            // Return a 200 response to confirm it has completed
            return Ok();
        }
    
        /// <summary>
        /// The endpoint for getting the information on where to pick up a listing once purchaced.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("pickup")]
        public async Task<ActionResult<ListingSellerVM>> GetPickupInfo(Guid id)
        {
            var result = await _listingService.GetPickupInfo(id);

            return Ok(result);
        }

    }
}
