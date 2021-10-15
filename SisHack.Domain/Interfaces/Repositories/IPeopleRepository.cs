using SisHack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisHack.Domain.Interfaces.Repositories
{
    public interface IPeopleRepository : IDisposable
    {
        #region Public Methods

        Task AddAsync(People people);

        void Update(People people);

        Task<People> GetAsync(Guid id);

        Task<People> GetByNameAsync(string name);

        Task<IEnumerable<People>> GetAllAsync();

        #endregion Public Methods
    }
}