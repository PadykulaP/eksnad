using Exercise.Domain;
using Exercise.Domain.Aggregates;
using Exercise.Domain.NotificationSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Infrastructure
{
    public class NotificationRepository: INotificationRepository
    {
        private static List<Company> _companies = new List<Company>
        {
            new Company
            {
                Id = "ddd7a630-af1c-4952-9cb4-44b8b847853b",
                CompanyNumber="0123456789",
                CompanyType = Settings.CompanyType.small,
                Market = "Denmark",
            },
            new Company
            {
                Id = "nnd7a630-af1c-4952-9cb4-44b8b847853b",
                CompanyNumber="0123456789",
                CompanyType = Settings.CompanyType.large,
                Market = "Norway"
            },
            new Company
            {
                Id = "ssd7a630-af1c-4952-9cb4-44b8b847853b",
                CompanyNumber="0123456789",
                CompanyType = Settings.CompanyType.medium,
                Market = "Sweden"
            },
            new Company
            {
                Id = "ffd7a630-af1c-4952-9cb4-44b8b847853b",
                CompanyNumber="0123456789",
                CompanyType = Settings.CompanyType.large,
                Market = "Finland"
            },
            new Company
            {
                Id = "ff2d7a630-af1c-4952-9cb4-44b8b847853b",
                CompanyNumber="0123456789",
                CompanyType = Settings.CompanyType.small,
                Market = "Finland"
            }
        };
        private static Dictionary<string, List<DateTime>> _companiesNotificationCreationAttempts = new Dictionary<string, List<DateTime>>();
        public Company GetCompany(string companyId)
        {
            return _companies.FirstOrDefault(x => x.Id == companyId);
        }

        public void LogAttempt(Company company)
        {
            if(!_companiesNotificationCreationAttempts.ContainsKey(company.Id))
            {
                _companiesNotificationCreationAttempts.Add(company.Id, new List<DateTime> { DateTime.UtcNow });
                return;
            }
            _companiesNotificationCreationAttempts[company.Id].Add(DateTime.UtcNow);
        }

        public void Save(Company company)
        {
            Company c = GetCompany(company.Id);
            if(c is null)
            {
                _companies.Add(new Company {
                    Id = company.Id,
                    CompanyNumber  = new Random(100).ToString(),
                    CompanyType = Settings.CompanyType.small,
                    Market = "Denmark"
                });
            }
            c.NotificationPlan = company.NotificationPlan;
        }
    }
}
