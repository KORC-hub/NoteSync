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
    internal class FolderRepository : IFolderRepository<IFolder>
    {
        private readonly NoteSyncDbContext _context;
        private readonly IMapper _mapper;

        public FolderRepository(NoteSyncDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<IFolder> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IFolder>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(IFolder model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IFolder model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
