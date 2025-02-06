import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/enviroment/enviroment';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private baseUrl:string=environment.apiUrl;
  constructor(private _http:HttpClient) { }

  getStudents(){
    const url = `${this.baseUrl}Student`;
    return this._http.get(url);
  }

  postStudents(data:any){ 
    const url = `${this.baseUrl}Student/Addstudent`;
    const httpOptions={
      headers:new HttpHeaders({'content-Type':'application/json'})
    };
    return this._http.post(url,data,httpOptions);
  }

  updateStudents(id:any,data:any):Observable<any>{
    const url=`${this.baseUrl}Student/Updatestudent${id}`;
    return this._http.put(url,data);
  }

  deleteStudents(id:any):Observable<any>{
    const url=`${this.baseUrl}Student/DeleteStudent${id}`;
    return this._http.delete(url);
  }

  getStudentSearch(searchTxt:string){
    const url = `${this.baseUrl}Student/SearchStudent${searchTxt}`;
    return this._http.get(url);
  }

}
