using Exercise.Domain.Aggregates;
using Exercise.Domain.NotificationSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Application.Interfaces
{
    public interface INotificationService
    {
        NotificationPlan CreateNotificationSchedule(string country, int size, DateTime callDate);
        Company ProcessNotificationCall(string companyId);
    }
}
