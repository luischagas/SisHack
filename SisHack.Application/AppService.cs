

using System.Threading.Tasks;
using FluentValidation.Results;
using SisHack.Domain.Interfaces.UnitOfWork;
using SisHack.Domain.Shared.Interface.Notification;
using SisHack.Domain.Shared.Notifications;

namespace SisHack.Application
{
    public abstract class AppService
    {
        #region Private Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly INotifier _notifier;

        #endregion Private Fields

        #region Protected Constructors

        protected AppService(IUnitOfWork unitOfWork, INotifier notifier)
        {
            _unitOfWork = unitOfWork;
            _notifier = notifier;
        }

        #endregion Protected Constructors

        #region Public Methods

        public async Task<bool> CommitAsync()
        {
            if (await _unitOfWork.CommitAsync())
                return await Task.FromResult(true);

            return await Task.FromResult(false);
        }

        #endregion Public Methods

        #region Protected Methods

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                Notify(error.ErrorMessage);
        }

        protected void Notify(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }

        #endregion Protected Methods
    }
}