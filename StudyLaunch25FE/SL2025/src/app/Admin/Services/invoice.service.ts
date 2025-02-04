import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/enviroment/enviroment';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  private baseUrl:string=environment.apiUrl;
    constructor(private _http:HttpClient) { }
  
    getFeeDetails(){
      const url = `${this.baseUrl}Fee/GetFeeDetails`;
      return this._http.get(url);
    }
  
    postPaymentDetail(data:any){ 
      const url = `${this.baseUrl}Fee/SubmitFeeDetails`;
      const httpOptions={
        headers:new HttpHeaders({'content-Type':'application/json'})
      };
      return this._http.post(url,data,httpOptions);
    }
  }