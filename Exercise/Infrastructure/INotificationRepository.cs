using Exercise.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Infrastructure
{
    public interface INotificationRepository
    {
        Company GetCompany(string companyId);
        void Save(Company company);
        void LogAttempt(Company company);
    }
}
