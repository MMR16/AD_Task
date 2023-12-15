import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DepartmentService } from 'src/app/Core/Services/department.service';
import { DisplayDepartment } from 'src/app/Shared/models/department/DisplayDepartment';

@Component({
  selector: 'app-display-department',
  templateUrl: './display-department.component.html',
  styleUrls: ['./display-department.component.scss']
})
export class DisplayDepartmentComponent {

  departments: DisplayDepartment[];

  constructor(private departmentService: DepartmentService, private router: Router) { }
  ngOnInit() {
    this.departmentService.getDepartments().subscribe({
      next: e => this.departments = e,
      error: e => alert(e.message)
    });
  }

  AddDepartment() {
    this.router.navigate(['/addDepartment']);
  }

  EditDepartment(id: number) {

    this.router.navigate(['/editDepartment', id]);
  }

  deleteDepartment(id: number) {
    const isConfirmed = window.confirm('Are you sure you want to delete this Department?');
    if (isConfirmed) {
      this.departmentService.deleteDepartment(id).subscribe({
        next: () => alert('deleted'),
        error: () => alert('error Happend')
      });
      this.ngOnInit();
      this.router.navigate(['/departments']);
    }
  }

}
