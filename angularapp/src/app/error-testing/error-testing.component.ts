import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-error-testing',
  templateUrl: './error-testing.component.html',
  styleUrls: ['./error-testing.component.css']
})
export class ErrorTestingComponent {

  baseUrl = "https://localhost:7202/api/";

  constructor(private http: HttpClient) { }

  unauthorized() {
    return this.http.get(this.baseUrl + "bugtesting/GetUnauthorized").subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }

  notfound() {
    return this.http.get(this.baseUrl + "bugtesting/GetNotFound").subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }

  servererror() {
    return this.http.get(this.baseUrl + "bugtesting/GetServerException").subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }

  badrequest() {
    return this.http.get(this.baseUrl + "bugtesting/GetBadRequest").subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }
}
