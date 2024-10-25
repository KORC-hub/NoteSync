using AutoMapper;
using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServer.Repositories
{
    internal class PageRepository : IPageRepository<IPage>
    {
        private readonly NoteSyncDbContext _context;
        private readonly IMapper _mapper;

        public PageRepository(NoteSyncDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<IEnumerable<IPage>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(IPage model)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(IPage model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
