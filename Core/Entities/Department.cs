using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Department:BaseEntity  
    {
        public string Name { get; set; }

        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }
        public  Employee Manager { get; set; }
    }
}
