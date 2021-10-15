using System.Collections.Generic;
using System.Linq;
using SisHack.Domain.Shared.Interface.Notification;

namespace SisHack.Domain.Shared.Notifications
{
    public class Notifier : INotifier
    {
        #region Private Fields

        private readonly List<Notification> _notifications;

        #endregion Private Fields

        #region Public Constructors

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        #endregion Public Constructors

        #region Public Methods

        public List<Notification> GetAllNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        #endregion Public Methods
    }
}