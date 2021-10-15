using SisHack.Infrastructure.Context;
using System;
using System.Threading.Tasks;
using SisHack.Domain.Interfaces.UnitOfWork;

namespace SisHack.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SisHackContext _context;

        public UnitOfWork(SisHackContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}