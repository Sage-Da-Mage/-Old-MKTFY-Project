using MKTFY.Models.ViewModels.FAQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Services.Interfaces
{
    /// <summary>
    /// The interface for the service layer of FAQs.
    /// </summary>
    public interface IFAQService
    {
        Task<FAQVM> Create(FAQAddVM src);

        Task<FAQVM> Get(Guid id);

        Task<List<FAQVM>> GetAll();

        Task<FAQVM> Update(FAQUpdateVM src);

    }
}
