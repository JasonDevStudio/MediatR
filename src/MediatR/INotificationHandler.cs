using System.Threading;
using System.Threading.Tasks;

namespace MediatR;

/// <summary>
/// Defines a handler for a notification
/// </summary>
/// <typeparam name="TNotification">The type of notification being handled</typeparam>
public interface INotificationHandler<in TNotification>
    where TNotification : INotification
{
    /// <summary>
    /// Gets or sets the priority.
    /// </summary>
    /// <value>
    /// The priority.
    /// </value>
    decimal Priority { get; set; }

    /// <summary>
    /// Gets or sets the level.
    /// </summary>
    /// <value>
    /// The level.
    /// </value>
    int Level { get; set; }

    /// <summary>
    /// Handles a notification
    /// </summary>
    /// <param name="notification">The notification</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task Handle(TNotification notification, CancellationToken cancellationToken);
}

/// <summary>
/// Wrapper class for a synchronous notification handler
/// </summary>
/// <typeparam name="TNotification">The notification type</typeparam>
public abstract class NotificationHandler<TNotification> : INotificationHandler<TNotification>
    where TNotification : INotification
{
    Task INotificationHandler<TNotification>.Handle(TNotification notification, CancellationToken cancellationToken)
    {
        Handle(notification);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Gets or sets the priority.
    /// </summary>
    /// <value>
    /// The priority.
    /// </value>
    public decimal Priority { get; set; }

    /// <summary>
    /// Gets or sets the level.
    /// </summary>
    /// <value>
    /// The level.
    /// </value>
    public int Level { get; set; }

    /// <summary>
    /// Override in a derived class for the handler logic
    /// </summary>
    /// <param name="notification">Notification</param>
    protected abstract void Handle(TNotification notification);
}