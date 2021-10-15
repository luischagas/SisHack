using Microsoft.EntityFrameworkCore;
using SisHack.Domain.Entities;
using SisHack.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SisHack.Domain.Interfaces.Repositories;

namespace SisHack.Infrastructure.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        #region Private Fields

        private readonly DbSet<People> _people;
        private readonly SisHackContext _db;

        #endregion Private Fields

        #region Public Constructors

        public PeopleRepository(SisHackContext db)
        {
            _db = db;
            _people = _db.Set<People>();
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task AddAsync(People people)
        {
            await _people
                .AddAsync(people);
        }

        public void Update(People people)
        {
            _db.Update(people);
        }

        public async Task<People> GetAsync(Guid id)
        {
            return await _people
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<People> GetByNameAsync(string name)
        {
            return await _people
                .FirstOrDefaultAsync(d => d.Name == name);
        }

        public async Task<IEnumerable<People>> GetAllAsync()
        {
            return await _people
                .ToListAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion Public Methods

    }
}