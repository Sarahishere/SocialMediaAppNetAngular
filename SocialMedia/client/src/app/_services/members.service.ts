import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getMembers(){
    return this.http.get<Member[]>(this.baseUrl + '/v1/users');
  }

  getMember(username: string) {
    return this.http.get<Member>(this.baseUrl + '/v1/users/' + username);
  }

  updateMember(member: Member) {
    return this.http.put(this.baseUrl + '/v1/users',member);
  }

}
