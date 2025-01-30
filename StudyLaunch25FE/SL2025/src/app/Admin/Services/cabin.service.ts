import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/enviroment/enviroment';

@Injectable({
  providedIn: 'root'
})
export class CabinService {
private baseUrl:string=environment.apiUrl;
  constructor(private _http:HttpClient) { }

  getCabins(){
    const url = `${this.baseUrl}Cabin/GetCabins`;
    return this._http.get(url);
  }

  postCabins(data:any){ 
    const url = `${this.baseUrl}Cabin/AddCabin`;
    const httpOptions={
      headers:new HttpHeaders({'content-Type':'application/json'})
    };
    return this._http.post(url,data,httpOptions);
  }

  updateCabins(id:any,data:any):Observable<any>{
    const url=`${this.baseUrl}Cabin/updateCabin${id}`;
    return this._http.put(url,data);
  }

  deleteCabins(id:any):Observable<any>{
    const url=`${this.baseUrl}Cabin/deleteCabin${id}`;
    return this._http.delete(url);
  }
}
