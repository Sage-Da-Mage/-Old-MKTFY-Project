using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.FAQ
{
    /// <summary>
    /// The View model class for FAQs.
    /// </summary>
    public class FAQVM
    {
        /// <summary>
        /// The empty constructor for FAQVM.
        /// </summary>
        public FAQVM()
        {

        }

        /// <summary>
        /// The constructor for generating an FAQVM from an entity
        /// </summary>
        /// <param name="src"></param>
        public FAQVM(Entities.FAQ src)
        {
            Id = src.Id;
            Question = src.Question;
            Answer = src.Answer;
        }

        /// <summary>
        /// The Id of the FAQVM to differenciate it from other FAQVMs.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Question of the FAQVM
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// The Answer to the above question. 
        /// </summary>
        public string Answer { get; set; }
    }
}
