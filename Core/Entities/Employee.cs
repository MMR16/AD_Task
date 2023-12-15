using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public Decimal Salary { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public  Department Department { get; set; }

        //[ForeignKey("Manger")]
        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }
    }


}
