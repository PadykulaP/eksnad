using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercise.Application.Interfaces;
using Exercise.Domain;
using Exercise.Presentation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using Exercise.Domain.Aggregates;

namespace Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;
        public NotificationController(INotificationService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Welcome", "in" ,"aml notification", "project"};
        }

        [HttpGet("{companyId}")]
        public async Task<IActionResult> Get(string companyId)
        {
            Company company = await Task.Run(()  => _service.GetNotification(companyId));
            if (company is null)
                return BadRequest($"Company with id:{companyId} does not exist or is not allowed in the system.");
            if (company.NotificationPlan is null)
                return BadRequest($"Company with id:{companyId} has not created notification plan yet.");
            var dto = Application.Mappers.MapToDto.MapToNotificationPlan(company);
            return Ok(JsonConvert.SerializeObject(dto));
        }
        [HttpPost]
        public async Task<IActionResult> Post(Request request)
        {
            Company company = await Task.Run(() => _service.ProcessNotificationCall(request.CompanyId));
            if (company is null)
                return BadRequest($"Company with id:{request.CompanyId} does not exist or is not allowed in the system.");
            var dto = Application.Mappers.MapToDto.MapToNotificationPlan(company);
            return Ok(JsonConvert.SerializeObject(dto));
        }
    }
}
