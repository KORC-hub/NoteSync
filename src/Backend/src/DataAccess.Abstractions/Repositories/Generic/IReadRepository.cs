﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstractions.Repositories.Generic
{
    public interface IReadRepository<T>
    {
        Task<T> GetByIdAsync(int id);
    }
}
