import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { UserToken } from '../_models/user-token';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  model: any = {};

  constructor(public accountService: AccountService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {}

  login() {
    this.accountService.login(this.model).subscribe({
      next: () => this.router.navigateByUrl('/items/user-item-list')
    });
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
