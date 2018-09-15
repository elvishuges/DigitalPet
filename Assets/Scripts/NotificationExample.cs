using System;
using UnityEngine;

namespace Assets.SimpleAndroidNotifications
{
    public class NotificationExample : MonoBehaviour
    {
        
		// agenda simples
        public void ScheduleSimple()
        {
			NotificationManager.Send(TimeSpan.FromSeconds(10), "se passaram 10 segundos..", "Cuide do seu Pet Digital", new Color(1, 0.3f, 0.15f),NotificationIcon.Heart);
        }
		//normal agenda
        public void ScheduleNormal()
        {
            NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(5), "se passaram 5 segundos..", "Notification with app icon", new Color(0, 0.6f, 1), NotificationIcon.Message);
        }

        public void ScheduleCustom()
        {
            var notificationParams = new NotificationParams
            {
                Id = UnityEngine.Random.Range(0, int.MaxValue),
                Delay = TimeSpan.FromSeconds(0),
                Title = "Custom notification",
                Message = "Message",
                Ticker = "Ticker",
                Sound = true,
                Vibrate = true,
                Light = true,
                SmallIcon = NotificationIcon.Heart,
                SmallIconColor = new Color(0, 0.5f, 0),
                LargeIcon = "app_icon"
            };

            NotificationManager.SendCustom(notificationParams);
        }

        public void CancelAll()
        {
            NotificationManager.CancelAll();
        }
    }
}