using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Domain.NotificationSchedule
{
    public class NotificationPlan
    {
        public NotificationPlan()
        {
            Schedule = new Dictionary<int, DateTime>();
        }
        public Dictionary<int, DateTime> Schedule { get; private set; }
        public void AddSchemaItem(int i, DateTime date)
        {
            Schedule.Add(i, date);
        }
    }
}
