using MKTFY.Models.Entities;
using MKTFY.Models.ViewModels.FAQ;
using MKTFY.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MKTFY.Repositories.Repositories.Interfaces;

namespace MKTFY.Services
{
    /// <summary>
    /// The Service layer for FAQs, creats, gets and updates them.
    /// </summary>
    public class FAQService : IFAQService
    {
        private readonly IFAQRepository _faqRepository;

        public FAQService(IFAQRepository FAQRepository)
        {
            _faqRepository = FAQRepository;
        }
        public async Task<FAQVM> Create(FAQAddVM src)
        {
            var newFAQEntity = new FAQ(src);

            // Add the DateTime that the FAQ was created
            newFAQEntity.DateCreated = DateTime.UtcNow;

            
            var result = await _faqRepository.Create(newFAQEntity);
            var model = new FAQVM(result);
            return model;
        }

        public async Task<FAQVM> Get(Guid id)
        {
            var result = await _faqRepository.Get(id);
            var model = new FAQVM(result);
            return model;
        }

        public async Task<List<FAQVM>> GetAll()
        {
            var results = await _faqRepository.GetAll();
            var models = results.Select(FAQ => new FAQVM(FAQ)).ToList();
            return models;
        }

        public async Task<FAQVM> Update(FAQUpdateVM src)
        {
            var updateData = new FAQ(src);
            var result = await _faqRepository.Update(updateData);
            var model = new FAQVM(result);
            return model;


        }
    }
}
