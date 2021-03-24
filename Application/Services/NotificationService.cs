using System.Collections.Generic;
using FluentValidation.Results;
using Domain.DomainNotifications;
using Domain.Entity;
using System;

namespace Application.Services.NotificationService
{
  public class NotificationService : INotificationService
  {
    private readonly NotificationContext _notificationContext;
    public NotificationService(NotificationContext notificationContext)
    {
      _notificationContext = notificationContext;
    }

    public void AddNotification(string key, string value)
    {
      _notificationContext.AddNotification(key, value);
    }

    public void AddEntityNotifications(ValidationResult validationResult)
    {
      _notificationContext.AddNotifications(validationResult);
    }

    public bool HasNotifications()
    {
      return _notificationContext.HasNotifications;
    }

    public IReadOnlyCollection<Notification> GetNotifications()
    {
      return _notificationContext.Notifications;
    }

    public bool IsEntityValid(BaseEntity entity)
    {
      entity.Validate();
      if (!entity.IsValid)
      {
        this.AddEntityNotifications(entity.ValidationResult);
        return false;
      }
      return true;
    }

    public bool IsGuidValid(Guid guid)
    {
      if (guid == Guid.Empty || guid == null)
      {
        this.AddNotification("idInvalido", "O id informado está inválido: " + guid.ToString());
        return false;
      }
      return true;
    }
  }
}
