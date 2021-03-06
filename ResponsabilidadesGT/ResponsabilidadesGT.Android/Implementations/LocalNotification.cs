﻿using System;

namespace ResponsabilidadesGT.Droid.Implementations
{
    public class LocalNotification
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int Id { get; set; }
        public int IconId { get; set; }
        public DateTime NotifyTime { get; set; }
        public bool HasSound { get; set; }
        public bool HasVibration { get; set; }
    }
}