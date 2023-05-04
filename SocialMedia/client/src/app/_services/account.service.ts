import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:7182/api/'

  constructor(private http: HttpClient) { }
  login(model: any){
    return this.http.post(this.baseUrl + 'v1/account/login',model)
  }
}
