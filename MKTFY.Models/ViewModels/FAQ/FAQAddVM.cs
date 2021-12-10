using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.FAQ
{
    /// <summary>
    /// The class for generating a new FAQ.
    /// </summary>
    public class FAQAddVM
    {
        /// <summary>
        /// The Question that has been asked frequently.
        /// </summary>
        [Required]
        public string Question { get; set; }

        /// <summary>
        /// The Answer to the question asked.
        /// </summary>
        [Required]
        public string Answer { get; set; }

    }
}
