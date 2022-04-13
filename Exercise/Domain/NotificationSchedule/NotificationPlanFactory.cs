using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Domain.NotificationSchedule
{
    public class NotificationPlanFactory
    {
        private readonly NotificationSchedule _schedule;
        public NotificationPlanFactory(NotificationSchedule schedule)
        {
            _schedule = schedule;
        }
        public NotificationPlan CreateNotificationPlan(DateTime callDate, Settings.CompanyType companyType)
        {
            int[] schedule = _schedule.GetSchedule(companyType);
            if(schedule == null)
            {
                return null;
            }
            NotificationPlan plan = new NotificationPlan();
            foreach (var n in schedule)
            {
                plan.AddSchemaItem(n, callDate.AddDays(n));
            }
            return plan;
        }
    }
}
