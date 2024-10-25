using AutoMapper;
using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.SqlServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServer.Repositories
{
    class TagRepository : ITagRepository<ITag>
    {
        private readonly NoteSyncDbContext _context;
        private readonly IMapper _mapper;

        public TagRepository(NoteSyncDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task CreateAsync(ITag model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ITag>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ITag> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ITag model)
        {
            throw new NotImplementedException();
        }
    }
}
