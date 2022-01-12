using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreDate = DateTime.Now;
        }
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual DateTime CreDate { get; set; }

    }
    }
