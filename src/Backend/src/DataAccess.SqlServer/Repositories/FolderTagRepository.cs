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
    internal class FolderTagRepository : IFolderTagRepository<IFolderTag>
    {
        private readonly NoteSyncDbContext _context;
        private readonly IMapper _mapper;

        public FolderTagRepository(NoteSyncDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<IEnumerable<IFolderTag>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(IFolderTag model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
