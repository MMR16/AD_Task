import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddEmployee } from 'src/app/Shared/models/employee/AddEmployee';
import { DisplayEmployee } from 'src/app/Shared/models/employee/DisplayEmployee';
import { EditEmployee } from 'src/app/Shared/models/employee/EditEmployee';
import { EmployeeDetails } from 'src/app/Shared/models/employee/EmployeeDetails';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  baseUrl: string = environment.apiUrl;


  constructor(private http: HttpClient) { }



  getEmployees() {
    return this.http.get<DisplayEmployee[]>(this.baseUrl + 'Employee')
  }

  addEmployee(emp: AddEmployee) {
    return this.http.post<AddEmployee>(this.baseUrl + 'Employee', emp)
  }

  getEmployeeById(id: number) {
    return this.http.get<DisplayEmployee>(this.baseUrl + 'Employee/' + id)
  }


  EditEmployee(emp: EditEmployee) {
    return this.http.put<EditEmployee>(this.baseUrl + 'Employee', emp)
  }

  getManagerIdbyManagerName(managerName: string) {
    return this.http.get<any>(this.baseUrl + 'Employee/' + managerName)
  }
  getEmployeeDetailsById(id: number) {
    return this.http.get<EmployeeDetails>(this.baseUrl + 'Employee/details/' + id)
  }


  deleteEmployee(id: number) {
    return this.http.delete<DisplayEmployee>(this.baseUrl + 'Employee/' + id)
  }
}

