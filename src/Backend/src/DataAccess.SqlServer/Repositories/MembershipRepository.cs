using DataAccess.Abstractions.Models;
using DataAccess.Abstractions.Repositories.Specific;
using DataAccess.SqlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.SqlServer.Repositories
{
    public class MembershipRepository : IMembershipRepository<IMembership>
    {
        private readonly NoteSyncDbContext _context;

        public MembershipRepository(NoteSyncDbContext context)
        {
            _context = context;
        }

        public async Task<IMembership> GetByIdAsync(int id)
        {
            try
            {
                Membership? membership = await _context.Memberships.FindAsync((byte)id);

                if (membership == null)
                {
                    throw new Exception();
                }

                return membership;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the membership from the database.", ex);
            }
        }
    }
}
