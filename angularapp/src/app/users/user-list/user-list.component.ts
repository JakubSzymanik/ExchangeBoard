import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/user';
import { UsersService } from '../../_services/users.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent {
  users: User[] = [];

  constructor(private http: HttpClient, private usersService: UsersService) { }

  ngOnInit(): void
  {
    this.usersService.getUsers().subscribe({
        next: Response => this.users = Response
      })
  }
}
