using System.Collections.Generic;

namespace SisHack.Domain.Shared.Interface.Notification
{
    public interface INotifier
    {
        #region Public Methods

        List<Notifications.Notification> GetAllNotifications();

        void Handle(Notifications.Notification notification);

        bool HasNotification();

        #endregion Public Methods
    }
}