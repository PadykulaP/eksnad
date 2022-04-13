using Exercise.Domain.NotificationSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Domain.Aggregates
{
    public class Company
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CompanyNumber { get; set; }
        public string Market { get; set; }
        public Settings.CompanyType CompanyType { get; set; }
        public NotificationPlan NotificationPlan { get; set; }
    }
}
