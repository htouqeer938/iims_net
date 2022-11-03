import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class SharedService {
  readonly APIUrl = 'http://localhost:5290/api';
  readonly PhotoUrl = 'http://localhost:5290/Photos';

  constructor(private http: HttpClient) { }

  getDepList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Department');
  }

  getDep(val: any): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Department/' + val);
  }

  addDepartment(val: any) {
    return this.http.post(this.APIUrl + '/Department', val);
  }

  updateDepartment(val: any, id: number) {
    return this.http.put(this.APIUrl + `/Department/${id}`, val);
  }

  deleteDepartment(val: any) {
    return this.http.delete(this.APIUrl + '/Department/' + val);
  }

  UploadFile(val: any) {
    return this.http.post(this.APIUrl + 'SaveFile', val);
  }
}
