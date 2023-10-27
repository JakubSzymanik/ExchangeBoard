import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { UserToken } from '../_models/user-token';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new BehaviorSubject<UserToken | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  // sprawdź czy jest zapisany user w localstorage, jak tak to wywołaj obserwabla - odpalane z appcomponent
  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user: UserToken = JSON.parse(userString);
    this.currentUserSource.next(user);
  }

  login(model: any) {
    return this.http.post<UserToken>(this.baseUrl + "account/login", model).pipe(
      map((response: UserToken) => {
        const user = response;
        if (user) //!= null
        {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

  register(model: any) {
    return this.http.post<UserToken>(this.baseUrl + "account/register", model).pipe(
      map((response: UserToken) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
  }

  getHttpOptions() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user = JSON.parse(userString);
    return {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + user.token
      })
    }
  }
}
