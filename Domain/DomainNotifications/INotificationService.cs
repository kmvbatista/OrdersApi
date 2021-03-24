using System;
using System.Collections.Generic;
using Domain.Entity;

namespace Domain.DomainNotifications
{
  public interface INotificationService
  {
    void AddNotification(string key, string value);
    void AddEntityNotifications(FluentValidation.Results.ValidationResult validationResult);
    bool HasNotifications();
    IReadOnlyCollection<Notification> GetNotifications();
    bool IsEntityValid(BaseEntity entity);
    bool IsGuidValid(Guid guid);
  }
}
