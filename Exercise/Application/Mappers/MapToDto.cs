using Exercise.Domain.Aggregates;
using Exercise.Domain.NotificationSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Application.Mappers
{
    public static class MapToDto
    {
        public static string DateFormat(DateTime x)
        {
            return $"{x.Day.ToString().PadLeft(2, '0')}/{x.Month.ToString().PadLeft(2, '0')}/{x.Year}";
        }
        public static Presentation.NotificationPlan MapToNotificationPlan(Company domain)
        {
            return new Presentation.NotificationPlan
            {
                companyId = domain.Id,
                notifications = domain.NotificationPlan.Schedule.Select(x => DateFormat(x.Value))
            };
        }
    }
}
