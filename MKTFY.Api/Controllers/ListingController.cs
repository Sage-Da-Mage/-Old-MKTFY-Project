using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKTFY.Api.Helpers;
using MKTFY.Models.ViewModels;
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
        [HttpPut("listing/{id}")]
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
        /// Get a series of listings from the category type(CategoryId).
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet("category/{categoryId")]
        public async Task<ActionResult<List<ListingVM>>> GetByCategory([FromRoute]int categoryId, string city)
        {
            // Get the users Id and then narrow the check for listing by the Category and city
            string userId = User.GetId();
            var result = await _listingService.GetByCategory(categoryId, city, userId);
            
            return Ok(result);

        }

        /// <summary>
        /// Get listings based on the users search history. "Listings tailored for the user"
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet("listing/category/deals")]
        public async Task<ActionResult<List<ListingVM>>> GetDeals(string city)
        {
            string userId = User.GetId();
            var result = await _listingService.GetDeals(userId, city);
            return Ok(result);
        }


        /// <summary>
        /// Get a series of listings from an inputted string of terms.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet("search")]
        public async Task<ActionResult<List<ListingVM>>> GetBySearchTerm(string searchTerm, string city)
        {
            var search = new SearchCreateVM();
            search.UserId = User.GetId();
            search.SearchTerm = searchTerm.ToLower();
            var result = await _listingService.GetBySearchTerm(search, city);
            return Ok(result);
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

        /// <summary>
        /// Get the list of the Listings that the user has purchased)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("mypurchases")]
        public async Task<ActionResult<List<ListingPurchaseVM>>> GetMyPurchases()
        {
            string userId = User.GetId();
            var results = await _listingService.GetMyPurchases(userId);

            // Return the list of purchaced listings
            return Ok(results);
        }

        /// <summary>
        /// Get the list of the Listings that the user has posted
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("mylisting/{status}")]
        public async Task<ActionResult<List<ListingSummaryVM>>> GetMyListings(string status)
        {
            string userId = User.GetId();
            var results = await _listingService.GetMyListings(userId, status);
            
            // Return the list of Listings the user has posted
            return Ok(results);
        }

        /// <summary>
        /// Get all of the Users Listings, regardless of status
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("mylisting")]
        public async Task<ActionResult<List<ListingSummaryVM>>> GetAllMyListings()
        {
            //get user id from the Http request
            string userId = User.GetId();
            var results = await _listingService.GetMyListings(userId, "all");
            return Ok(results);
        }


        /// <summary>
        /// Get a listing with the details of the seller and the number of listings they have
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("listing/{id}/seller")]
        public async Task<ActionResult<ListingsPlusSellerVM>> GetListingWithSeller([FromRoute] Guid id)
        {
            return Ok(await _listingService.GetListingWithSeller(id));
        }

        /// <summary>
        /// The endpoint for changing the transaction status of a listing.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPut("listing/{id}/{status}")]
        public async Task<ActionResult> ChangeTransactionStatus([FromRoute] Guid id, string status)
        {

            // Confirm the status is valid, return badrequest if not
            string[] validStatus = { "Listed", "Deleted", "Pending", "Cancelled", "Sold" };
            if (!validStatus.Contains(status))
            {
                return BadRequest(new { message = "invalid status" });
            }

            string buyerId = "";

            if (status == "Pending")
            {
                buyerId = User.GetId();
            }
            await _listingService.ChangeTransactionStatus(id, status, buyerId);
            return Ok();
        }

    }
}
