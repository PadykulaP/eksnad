using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Domain.NotificationSchedule
{
    public class NotificationSchedule
    {
        public string Country { get; set; }
        public Dictionary<Settings.CompanyType, int[]> Schedule { get; set; }
        public int[] GetSchedule(Settings.CompanyType type)
        {
            if (Schedule.ContainsKey(Settings.CompanyType.common) && Schedule[Settings.CompanyType.common] != null)
                return Schedule[Settings.CompanyType.common];
            if (Schedule.ContainsKey(type))
                return Schedule[type];
            return null;
        }
    }
}
