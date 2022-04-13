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
        public IActionResult Get(string companyId)
        {
            Company company = _service.ProcessNotificationCall(companyId);
            if (company is null)
                return BadRequest($"Company with id:{companyId} does not exist or is not allowed in the system.");
            var dto = Application.Mappers.MapToDto.MapToNotificationPlan(company);
            return Ok(JsonConvert.SerializeObject(dto));
        }
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
    }
}
