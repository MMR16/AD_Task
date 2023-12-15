import { FormGroup, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { DepartmentService } from './../../Core/Services/department.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeService } from 'src/app/Core/Services/employeeService.service';
import { DisplayDepartment } from 'src/app/Shared/models/department/DisplayDepartment';
import { DisplayEmployee } from 'src/app/Shared/models/employee/DisplayEmployee';
import { AddEmployee } from 'src/app/Shared/models/employee/AddEmployee';



@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.scss']
})
export class AddEmployeeComponent implements OnInit {

  departments: DisplayDepartment[]
  employees: DisplayEmployee[];
  employee: AddEmployee;

  constructor(private departmentService: DepartmentService, private employeeService: EmployeeService, private router: Router) { }

  ngOnInit(): void {
    this.departmentService.getDepartments().subscribe({
      next: e => this.departments = e,
      error: e => alert(e.message)
    });

    this.employeeService.getEmployees().subscribe({
      next: e => this.employees = e,
      error: e => alert(e.message)
    });
  }


  employeeForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.maxLength(100)]),
    salary: new FormControl(0, [Validators.required, Validators.max(100000), Validators.min(1000)]),
    managerId: new FormControl(0, Validators.required),
    departmentId: new FormControl(0, Validators.required),
  });

  onSubmit() {
    if (this.employeeForm.valid) {
      this.employee = this.employeeForm.value as AddEmployee;

      this.employeeService.addEmployee(this.employee).subscribe({
        next: () => this.router.navigate(['/']),
        error: e => alert(e)
      });
    }
  }
}
