import { DisplayEmployee } from './../../Shared/models/employee/DisplayEmployee';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeService } from 'src/app/Core/Services/employeeService.service';

@Component({
  selector: 'app-display-employee',
  templateUrl: './display-employee.component.html',
  styleUrls: ['./display-employee.component.scss']
})
export class DisplayEmployeeComponent implements OnInit {

  Employees: DisplayEmployee[];

  constructor(private employeeService: EmployeeService, private router: Router) { }
  ngOnInit() {
    this.employeeService.getEmployees().subscribe({
      next: e => this.Employees = e,
      error: e => alert(e.message)
    });
  }

  AddEmployee() {
    this.router.navigate(['/addEmployee']);
  }

  EditEmployee(id: number) {

    this.router.navigate(['/editEmployee', id]);
  }

  deleteEmployee(id: number) {
    const isConfirmed = window.confirm('Are you sure you want to delete this Employee?');

    if (isConfirmed) {
      this.employeeService.deleteEmployee(id).subscribe({
        next: () => alert('deleted'),
        error: () => alert('error Happend')
      });
      this.router.navigate(['/']);
    }
  }
}
