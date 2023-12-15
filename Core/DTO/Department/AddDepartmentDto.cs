using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Department
{
    public class AddDepartmentDto
    {
        [Required(ErrorMessage = "Department name is required"), MaxLength(100, ErrorMessage = "Department name max lentgth is 100 charachter")]
        public string Name { get; set; }
        public int? ManagerId { get; set; }
    }
}
