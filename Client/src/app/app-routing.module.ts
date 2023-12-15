import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DisplayEmployeeComponent } from './employee/display-employee/display-employee.component';
import { AddEmployeeComponent } from './employee/add-employee/add-employee.component';
import { EditEmployeeComponent } from './employee/edit-employee/edit-employee.component';
import { ErrorComponent } from './Shared/error/error.component';
import { AddDepartmentComponent } from './Department/add-department/add-department.component';
import { EditDepartmentComponent } from './Department/edit-department/edit-department.component';
import { DisplayDepartmentComponent } from './Department/display-department/display-department.component';

const routes: Routes = [
  { path: "", component: DisplayEmployeeComponent, title: 'employees Details' },
  { path: "addEmployee", component: AddEmployeeComponent, title: 'Add employee ' },
  { path: 'editEmployee/:id', component: EditEmployeeComponent, title: 'Update Employee' },
  { path: "departments", component: DisplayDepartmentComponent, title: 'department Details' },
  { path: "addDepartment", component: AddDepartmentComponent, title: 'Add Department ' },
  { path: 'editDepartment/:id', component: EditDepartmentComponent, title: 'Update Department' },
  { path: '**', component: ErrorComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
