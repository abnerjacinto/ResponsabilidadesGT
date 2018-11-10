using ResponsabilidadesGT.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ResponsabilidadesGT.Services
{
    public class NotificationService
    {
        public void Show(string title, string body, int id,int dias, DateTime notifyTime, bool hasSound = false, bool hasVibration = false)
        {
            DependencyService.Get<ILocalNotifications>().Show(title,body,id,dias,notifyTime,hasSound,hasVibration);
        }
        public void Cancel(int id)
        {
            DependencyService.Get<ILocalNotifications>().Cancel(id);
        }
    }
}