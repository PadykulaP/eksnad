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
        private List<Company> _companies = new List<Company>
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
        public Company GetCompany(string companyId)
        {
            return _companies.FirstOrDefault(x => x.Id == companyId);
        }
    }
}
