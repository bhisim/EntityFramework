using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.Models
{
    public class Customer : BaseEntity
    {

        public string CompanyTitle { get; set; }

        public string ContactPhone { get; set; }
    }
}
