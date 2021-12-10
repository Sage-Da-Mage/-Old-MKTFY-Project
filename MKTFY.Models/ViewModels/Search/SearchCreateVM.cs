using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels
{
    /// <summary>
    /// The VM that creates SearchItems.
    /// </summary>
    public class SearchCreateVM
    {
        /// <summary>
        /// The Id of the user who did the search.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The term that was searched.
        /// </summary>
        public string SearchTerm { get; set; }
    }
}
