using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Presentation
{
    public class NotificationPlan
    {
        public string companyId { get; set; }
        public IEnumerable<string> notifications { get; set; }
    }
}
