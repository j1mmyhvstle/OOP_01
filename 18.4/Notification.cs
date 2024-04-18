using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Do_an_nhom
{
    public class Notification
    {
        public string Message { get; set; }
        public DateTime Time { get; set; }

        public Notification(string message, DateTime time)
        {
            Message = message;
            Time = time;
        }
        // Nạp chồng toán tử == và != (so sánh trước khi thêm)
        public static bool operator ==(Notification a, Notification b)
        {
            return a.Message == b.Message && a.Time == b.Time;
        }
        public static bool operator !=(Notification a, Notification b)
        {
            return !(a == b);
        }
        public void ShowNotification()
        {
            Console.WriteLine($"Thông báo: {Message} vào lúc {Time}");
        }

        public void SaveNotification(Notification newNotification, string filePath)
        {
            List<Notification> existingNotifications = new List<Notification>();
            SerializationHelper.Deserialize(existingNotifications, filePath);
            // Kiểm tra
            bool isExisting = false;
            foreach (Notification existingNotification in existingNotifications)
            {
                if (newNotification == existingNotification) // operator
                {
                    isExisting = true;
                    break;
                }
            }
            // thêm vào danh sách
            if (!isExisting)
            {
                existingNotifications.Add(newNotification);
                SerializationHelper.Serialize(existingNotifications, filePath);
                Console.WriteLine("Thông báo đã được thêm.");
            }
            else
            {
                Console.WriteLine("Thông báo này đã tồn tại.");
            }
            List<Notification> notifications = new List<Notification> { this };
            SerializationHelper.Serialize(notifications, filePath);
        }
    }
}
