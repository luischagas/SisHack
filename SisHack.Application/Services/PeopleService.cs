using SisHack.Application.Interfaces;
using SisHack.Application.Models.Common;
using SisHack.Application.Models.People.Response;
using SisHack.Domain.Interfaces.Repositories;
using SisHack.Domain.Interfaces.UnitOfWork;
using SisHack.Domain.Shared.Interface.Notification;
using SisHack.Domain.Shared.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SisHack.Application.Models.People.Request;
using SisHack.Domain.Entities;

namespace SisHack.Application.Services
{
    public class PeopleService : AppService, IPeopleService
    {
        #region Private Fields

        private readonly INotifier _notifier;
        private readonly IPeopleRepository _peopleRepository;

        #endregion Private Fields

        #region Public Constructors

        public PeopleService(IUnitOfWork unitOfWork,
            INotifier notifier,
            IPeopleRepository peopleRepository) : base(unitOfWork, notifier)
        {
            _notifier = notifier;
            _peopleRepository = peopleRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<IAppServiceResponse> Get(Guid id)
        {
            var people = await _peopleRepository.GetAsync(id);

            if (people is null)
            {
                Notify("Pessoa não encontrada");

                return await Task.FromResult(new AppServiceResponse<ICollection<Notification>>(_notifier.GetAllNotifications(), "Erro ao obter pessoa.", false));
            }

            var response = new PeopleResponseModel()
            {
                Id = people.Id,
                Name = people.Name,
                PhoneNumber = people.PhoneNumber,
                Type = people.Type
            };

            return await Task.FromResult(new AppServiceResponse<PeopleResponseModel>(response, "Pessoa obtida com sucesso.", true));
        }

        public async Task<IAppServiceResponse> Add(PeopleRequestModel request)
        {
            var hasPeople = await _peopleRepository.GetByNameAsync(request.Name);

            if (hasPeople is not null)
            {
                Notify("Pessoa já existe");

                return await Task.FromResult(new AppServiceResponse<ICollection<Notification>>(_notifier.GetAllNotifications(), "Erro ao adicionar pessoa.", false));
            }

            var people = new People(request.Name, request.PhoneNumber, request.Type);

            if (people.IsValid())
                await _peopleRepository.AddAsync(people);
            else
            {
                Notify(people.ValidationResult);

                return await Task.FromResult(new AppServiceResponse<ICollection<Notification>>(_notifier.GetAllNotifications(), "Erro ao adicionar pessoa.", false));
            }

            if (await CommitAsync() is false)
            {
                Notify("Erro ao salvar dados");

                return await Task.FromResult(new AppServiceResponse<ICollection<Notification>>(_notifier.GetAllNotifications(), "Erro ao obter pessoa.", false));
            }

            return await Task.FromResult(new AppServiceResponse<object>(null, "Pessoa adicionada com sucesso.", true));
        }

        #endregion Public Methods
    }
}