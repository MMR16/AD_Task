import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddDepartment } from 'src/app/Shared/models/department/AddDepartment';
import { DepartmentDetails } from 'src/app/Shared/models/department/DepartmentDetails';
import { DisplayDepartment } from 'src/app/Shared/models/department/DisplayDepartment';
import { EditDepartment } from 'src/app/Shared/models/department/EditDepartment';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  baseUrl: string = environment.apiUrl;


  constructor(private http: HttpClient) { }

  getDepartments() {
    return this.http.get<DisplayDepartment[]>(this.baseUrl + 'Department')
  }


  addDepartment(emp: AddDepartment) {
    return this.http.post<AddDepartment>(this.baseUrl + 'Department', emp)
  }

  getDepartmentById(id: number) {
    return this.http.get<DisplayDepartment>(this.baseUrl + 'Department/' + id)
  }


  EditDepartment(emp: EditDepartment) {
    return this.http.put<EditDepartment>(this.baseUrl + 'Department', emp)
  }


  getDepartmentDetailsById(id: number) {
    return this.http.get<DepartmentDetails>(this.baseUrl + 'Department/details/' + id)
  }


  deleteDepartment(id: number) {
    return this.http.delete<any>(this.baseUrl + 'Department/' + id)
  }

}
