﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Department
{
    public class DepartmentDetailsDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }
    }
}