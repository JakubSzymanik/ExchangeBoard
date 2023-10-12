import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  model: any = {};
  @Output() cancelRegister = new EventEmitter();

  constructor(public accountService: AccountService) { }

  register() {
    this.accountService.register(this.model).subscribe({
      next: response => {
        console.log(response);
      },
      error: error => {
        console.log(error);
      }
    });
    this.cancelRegister.emit(false);
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
