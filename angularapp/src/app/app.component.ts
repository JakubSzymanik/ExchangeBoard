import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'Exchange Board';
  users: any;
  registerMode: boolean = false;

  constructor(private http: HttpClient, private accountService: AccountService) { }

  ngOnInit(): void {
    this.http.get('https://localhost:7202/api/users/getusers').subscribe(result => {
      this.users = result;
    }, error => console.error(error));

    this.accountService.setCurrentUser();
  }

  setRegisterMode(value: boolean) {
    this.registerMode = value;
  }
}
