import { EmployeeDetails } from './../../Shared/models/employee/EmployeeDetails';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DepartmentService } from 'src/app/Core/Services/department.service';
import { EmployeeService } from 'src/app/Core/Services/employeeService.service';
import { DisplayDepartment } from 'src/app/Shared/models/department/DisplayDepartment';
import { DisplayEmployee } from 'src/app/Shared/models/employee/DisplayEmployee';
import { EditEmployee } from 'src/app/Shared/models/employee/EditEmployee';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.scss']
})
export class EditEmployeeComponent implements OnInit {

  departments: DisplayDepartment[]
  employees: DisplayEmployee[];
  employee: EditEmployee;
  employeeId: number;
  employeeDetails: EmployeeDetails

  constructor(private departmentService: DepartmentService,
    private employeeService: EmployeeService,
    private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.employeeId = +this.route.snapshot.paramMap.get('id');
    this.departmentService.getDepartments().subscribe({
      next: e => this.departments = e,
      error: e => alert(e.message)
    });

    this.employeeService.getEmployees().subscribe({
      next: e => this.employees = e,
      error: e => alert(e.message)
    });

    this.employeeService.getEmployeeDetailsById(this.employeeId).subscribe({
      next: e => {
        this.employeeDetails = e
        this.employeeForm.patchValue({
          name: e.name,
          salary: e.salary,
          managerId: e.managerId,
          departmentId: e.departmentId,
        });
      },
      error: e => alert(e.messager)
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
      this.employee = this.employeeForm.value as EditEmployee;
      this.employee.id = this.employeeId;

      this.employeeService.EditEmployee(this.employee).subscribe({
        next: () => this.router.navigate(['/']),
        error: e => alert(e)
      });
    }
  }

}
