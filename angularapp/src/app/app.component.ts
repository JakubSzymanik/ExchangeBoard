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

  constructor(private http: HttpClient, private accountService: AccountService) { }

  ngOnInit(): void {
    this.accountService.setCurrentUser();
  }
}
