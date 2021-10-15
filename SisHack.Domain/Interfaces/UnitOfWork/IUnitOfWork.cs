using System;
using System.Threading.Tasks;

namespace SisHack.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        #region Public Methods

        Task<bool> CommitAsync();

        #endregion Public Methods
    }
}