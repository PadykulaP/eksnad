using Exercise.Application.Interfaces;
using Exercise.Domain.NotificationSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercise.Infrastructure;
using Exercise.Domain;
using Exercise.Domain.Aggregates;

namespace Exercise.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationScheduleRepository _scheduleRepository;
        private readonly INotificationRepository _notificationRepository;
        public NotificationService(INotificationScheduleRepository scheduleRepository, INotificationRepository notificationRepository)
        {
            _scheduleRepository = scheduleRepository;
            _notificationRepository = notificationRepository;
        }
        public Company ProcessNotificationCall(string companyId)
        {
            Company company = _notificationRepository.GetCompany(companyId);
            if(company is null)
            {
                //log error etc
                return null;
            }
            company.NotificationPlan = CreateNotificationSchedule(company.Market,(int)company.CompanyType, new DateTime(2022,1,1));
            if(company.NotificationPlan is null)
            {
                //log error
                //log in database attempt
                _notificationRepository.LogAttempt(company);
                return null;
            }
            _notificationRepository.Save(company);
            return company;
        }
        public Company GetNotification(string companyId)
        {
            Company company = _notificationRepository.GetCompany(companyId);
            if (company is null)
            {
                //log error etc
                return null;
            }
            return company;
        }
        public NotificationPlan CreateNotificationSchedule(string country, int size, DateTime callDate)
        {
            NotificationSchedule notificationSchemaForCountry = _scheduleRepository.GetNotificationSchedule(country);
            if(notificationSchemaForCountry is null)
            {
                //throws/log error
            }
            NotificationPlanFactory notificationPlanForCountry = new NotificationPlanFactory(notificationSchemaForCountry);
            return notificationPlanForCountry.CreateNotificationPlan(callDate, (Settings.CompanyType)size);
        }
    }
}
