import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DepartmentService } from 'src/app/Core/Services/department.service';
import { EmployeeService } from 'src/app/Core/Services/employeeService.service';
import { AddDepartment } from 'src/app/Shared/models/department/AddDepartment';
import { DisplayDepartment } from 'src/app/Shared/models/department/DisplayDepartment';
import { AddEmployee } from 'src/app/Shared/models/employee/AddEmployee';
import { DisplayEmployee } from 'src/app/Shared/models/employee/DisplayEmployee';

@Component({
  selector: 'app-add-department',
  templateUrl: './add-department.component.html',
  styleUrls: ['./add-department.component.scss']
})

export class AddDepartmentComponent {

  departments: DisplayDepartment[]
  department: AddDepartment;
  employees: DisplayEmployee[];

  constructor(private departmentService: DepartmentService, private employeeService: EmployeeService, private router: Router) { }

  ngOnInit(): void {

    this.employeeService.getEmployees().subscribe({
      next: e => this.employees = e,
      error: e => alert(e.message)
    });
  }


  departmentForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.maxLength(100)]),
    managerId: new FormControl(0, Validators.required),
  });

  onSubmit() {
    if (this.departmentForm.valid) {
      this.department = this.departmentForm.value as AddDepartment;

      this.departmentService.addDepartment(this.department).subscribe({
        next: () => this.router.navigate(['/departments']),
        error: e => alert(e)
      });
    }
  }
}
