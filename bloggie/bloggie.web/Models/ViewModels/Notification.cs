using bloggie.web.Enums;

namespace bloggie.web.Models.ViewModels
{
    public class Notification
    {
        public string message { get; set; }
        public NotificationType type { get; set;}
    }
}
