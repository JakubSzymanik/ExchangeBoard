import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { User } from '../_models/user';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUsers()
  {
    return this.http.get<User[]>(this.baseUrl + 'users/getusers');
  }

  getUserById(id: number) {
    return this.http.get<User>(this.baseUrl + 'users/getuser/' + id.toString());
  }
}
