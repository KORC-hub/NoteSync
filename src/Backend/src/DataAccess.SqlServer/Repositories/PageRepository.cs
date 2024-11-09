using AutoMapper;
using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServer.Repositories
{
    public class PageRepository : IPageRepository<IPage>
    {
        private readonly NoteSyncDbContext _context;
        private readonly IMapper _mapper;

        public PageRepository(NoteSyncDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<IPage>> GetAllAsync(int folderId)
        {
            try
            {
                List<Page> pageFromDataBase = await _context.Pages
                .Where(page => page.FolderId == folderId)
                .ToListAsync();

                List<IPage> pages = pageFromDataBase.Cast<IPage>().ToList();

                return pages;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred when trying to find Page by FolderId to the database.", ex);
            }
        }

        public async Task<List<int>> GetAllByFolderAsync(int folderId)
        {
            try
            {
                List<Page> pagegFromDataBase = await _context.Pages
                .Where(page => page.FolderId == folderId)
                .ToListAsync();

                List<int> pageIds = new List<int>();

                foreach (Page page in pagegFromDataBase)
                {
                    pageIds.Add(page.PageId);
                }

                return pageIds;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred when trying to find Page by FolderId to the database.", ex);
            }
        }

        public Task<int> CreateAsync(IPage model)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(IPage model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                Page page = await _context.Pages.FindAsync(id);
                if (page != null)
                {
                    _context.Pages.Remove(page);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Page could not be deleted from database", ex);
            }
        }
    }
}
