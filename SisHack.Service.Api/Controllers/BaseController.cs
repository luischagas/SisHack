using Microsoft.AspNetCore.Mvc;
using SisHack.Domain.Shared.Interface.Notification;
using System.Net;

namespace SisHack.Service.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        #region Private Fields

        private readonly INotifier _notifier;

        #endregion Private Fields

        #region Public Constructors

        public BaseController(INotifier notifier)
        {
            _notifier = notifier;
        }

        #endregion Public Constructors

        #region Protected Methods

        protected IActionResult GenerateResponse(HttpStatusCode statusCode, object result)
            => StatusCode((int)statusCode, result);

        protected bool ValidOperation()
        {
            return _notifier.HasNotification() is false;
        }

        #endregion Protected Methods
    }
}