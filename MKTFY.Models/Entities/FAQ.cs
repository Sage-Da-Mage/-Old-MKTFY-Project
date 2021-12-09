using MKTFY.Models.ViewModels.FAQ;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.Entities
{
    /// <summary>
    /// The Entity for FAQs, used to hold all the properties used for FAQs.
    /// </summary>
    public class FAQ
    {
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public FAQ()
        {

        }

        /// <summary>
        /// A constructor for creating an FAQ entity from an FAQVM
        /// </summary>
        /// <param name="src"></param>
        public FAQ(FAQCreateVM src)
        {
            Question = src.Question;
            Answer = src.Answer;


        }

        /// <summary>
        /// A Constructor for updating an FAQ entity previously existing from an FAQVM
        /// </summary>
        /// <param name="src"></param>
        public FAQ(FAQUpdateVM src)
        {
            Id = src.Id;
            Question = src.Question;
            Answer = src.Answer;

        }

        /// <summary>
        /// The Id is required so that we can differenciate the FAQ entities.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The question asked frequently to be answered.
        /// </summary>
        [Required]
        public string Question { get; set; }

        /// <summary>
        /// The Answer to the aformentioned question.
        /// </summary>
        [Required]
        public string Answer { get; set; }

        /// <summary>
        /// The time (in DateTime) that the FAQ was created.
        /// </summary>
        public DateTime DateCreated { get; set; }
    }
}
