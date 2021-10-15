using System;
using System.Threading.Tasks;
using SisHack.Application.Models.People.Request;

namespace SisHack.Application.Interfaces
{
    public interface IPeopleService
    {
        #region Public Methods

        Task<IAppServiceResponse> Get(Guid id);

        Task<IAppServiceResponse> Add(PeopleRequestModel request);

        #endregion Public Methods
    }
}