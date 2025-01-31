import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/enviroment/enviroment';

@Injectable({
  providedIn: 'root'
})
export class AssignmentService {
private baseUrl:string=environment.apiUrl;
  constructor(private _http:HttpClient) { }

  getAssignments(){
    const url = `${this.baseUrl}Assignment/GetAssignments`;
    return this._http.get(url);
  }

  postAssignment(data:any){ 
    const url = `${this.baseUrl}Assignment/AddAssignment`;
    const httpOptions={
      headers:new HttpHeaders({'content-Type':'application/json'})
    };
    return this._http.post(url,data,httpOptions);
  }

  updateAssignment(id:any,data:any):Observable<any>{
    const url=`${this.baseUrl}Assignment/UpdateAssignmnet${id}`;
    return this._http.put(url,data);
  }

  deleteAssignment(id:any):Observable<any>{
    const url=`${this.baseUrl}Assignment/DeleteAssignment${id}`;
    return this._http.delete(url);
  }
}