import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent {
  users: any = [];
  baseUrl = "https://localhost:7202/api/";

  constructor(private http: HttpClient) { }

  ngOnInit(): void
  {
    this.http.get(this.baseUrl + "users/getusers").subscribe({
      next: response => this.users = response
    })
  }
}
