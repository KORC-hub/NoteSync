using AutoMapper;
using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.SqlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.SqlServer.Repositories
{
    public class TagRepository : ITagRepository<ITag>
    {
        private readonly NoteSyncDbContext _context;
        private readonly IMapper _mapper;

        public TagRepository(NoteSyncDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(ITag tag)
        {
            try
            {
                Tag tagDataModel = _mapper.Map<Tag>(tag);
                await _context.Tags.AddAsync(tagDataModel);
                await _context.SaveChangesAsync();
                return tagDataModel.TagId;

            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred when trying to add the tag to the database.", ex);
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ITag>> GetAllAsync(int userId)
        {
            List<Tag> tagsFromDataBase = await _context.Tags
           .Where(tag => tag.UserId == userId)
           .ToListAsync();

            List<ITag> tags = tagsFromDataBase.Cast<ITag>().ToList();

            return tags;
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
