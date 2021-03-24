using Application.Services.NotificationService;
using Domain.DomainNotifications;

namespace Tests.Mocks
{
  public class NotificationServiceMock
  {
    public static INotificationService GetIt()
    {
      return new NotificationService(new NotificationContext());
    }
  }
}
