import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './Core/navbar/navbar.component';
import { DisplayEmployeeComponent } from './employee/display-employee/display-employee.component';
import { AddEmployeeComponent } from './employee/add-employee/add-employee.component';
import { RouterModule } from '@angular/router';
import { EditEmployeeComponent } from './employee/edit-employee/edit-employee.component';
import { ErrorComponent } from './Shared/error/error.component';
import { AddDepartmentComponent } from './Department/add-department/add-department.component';
import { DisplayDepartmentComponent } from './Department/display-department/display-department.component';
import { EditDepartmentComponent } from './Department/edit-department/edit-department.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    DisplayEmployeeComponent,
    AddEmployeeComponent,
    EditEmployeeComponent,
    ErrorComponent,
    AddDepartmentComponent,
    DisplayDepartmentComponent,
    EditDepartmentComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, HttpClientModule, RouterModule, ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
