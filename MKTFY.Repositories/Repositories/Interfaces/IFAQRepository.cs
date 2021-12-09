﻿using MKTFY.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories.Repositories.Interfaces
{
    /// <summary>
    /// The Interface for FAQ repository to work from.
    /// </summary>
    public interface IFAQRepository
    {
        Task<FAQ> Create(FAQ src);

        Task<FAQ> Get(Guid id);

        Task<List<FAQ>> GetAll();

        Task<FAQ> Update(FAQ src);
    }
}
