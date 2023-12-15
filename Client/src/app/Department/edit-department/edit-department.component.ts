import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DepartmentService } from 'src/app/Core/Services/department.service';
import { EmployeeService } from 'src/app/Core/Services/employeeService.service';
import { DepartmentDetails } from 'src/app/Shared/models/department/DepartmentDetails';
import { DisplayDepartment } from 'src/app/Shared/models/department/DisplayDepartment';
import { EditDepartment } from 'src/app/Shared/models/department/EditDepartment';
import { DisplayEmployee } from 'src/app/Shared/models/employee/DisplayEmployee';
import { EmployeeDetails } from 'src/app/Shared/models/employee/EmployeeDetails';

@Component({
  selector: 'app-edit-department',
  templateUrl: './edit-department.component.html',
  styleUrls: ['./edit-department.component.scss']
})
export class EditDepartmentComponent {

  departments: DisplayDepartment[]
  department: EditDepartment;
  departmentId: number;
  departmentDetails: DepartmentDetails
  employeeDetails: EmployeeDetails
  employees: DisplayEmployee[];

  constructor(private departmentService: DepartmentService, private employeeService: EmployeeService,
    private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.departmentId = +this.route.snapshot.paramMap.get('id');

    this.employeeService.getEmployees().subscribe({
      next: e => this.employees = e,
      error: e => alert(e.message)
    });

    this.departmentService.getDepartmentDetailsById(this.departmentId).subscribe({
      next: e => {
        this.departmentDetails = e
        this.departmentForm.patchValue({
          name: e.name,
          managerId: e.managerId,
        });
      },
      error: e => alert(e.messager)
    });
  }

  departmentForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.maxLength(100)]),
    managerId: new FormControl(0, Validators.required),
  });

  onSubmit() {
    if (this.departmentForm.valid) {
      this.department = this.departmentForm.value as EditDepartment;
      this.department.id = this.departmentDetails.id;

      this.departmentService.EditDepartment(this.department).subscribe({
        next: () => this.router.navigate(['/departments']),
        error: e => alert(e)
      });
    }
  }

}
