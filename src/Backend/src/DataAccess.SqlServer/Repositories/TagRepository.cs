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

        public async Task<List<ITag>> GetAllAsync(int userId)
        {
            List<Tag> tagsFromDataBase = await _context.Tags
           .Where(tag => tag.UserId == userId)
           .ToListAsync();

            List<ITag> tags = tagsFromDataBase.Cast<ITag>().ToList();

            return tags;
        }

        public async Task<ITag> GetByIdAsync(int id)
        {
            try
            {
                Tag? tag = await _context.Tags.FindAsync(id);

                if (tag == null)
                {
                    throw new Exception();
                }

                return tag;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the tag with id=" + id + " from the database.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                Tag tag = await _context.Tags.FindAsync(id);
                if (tag != null) 
                { 
                    _context.Tags.Remove(tag);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Tag could not be deleted from database", ex);
            }
        }
    }
}
