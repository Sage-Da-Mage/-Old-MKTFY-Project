using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.FAQ
{
    /// <summary>
    /// The Class for updating FAQs.
    /// </summary>
    public class FAQUpdateVM
    {
        /// <summary>
        /// The Id for differenciating FAQs and determine which FAQ to update.
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// The Question being asked frequently.
        /// </summary>
        [Required]
        public string Question { get; set; }

        /// <summary>
        /// The Answer to the aformentioned question.
        /// </summary>
        [Required]
        public string Answer { get; set; }

    }
}
