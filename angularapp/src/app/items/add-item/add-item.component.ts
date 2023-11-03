import { Component } from '@angular/core';
import { Item } from '../../_models/item';
import { ItemsService } from '../../_services/items.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../../_services/account.service';
import { take } from 'rxjs';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent {
  model: any = {};

  constructor(private itemService: ItemsService, private router: Router, private accountService: AccountService, private toastr: ToastrService) { }

  create()
  {
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: v => this.model.UserId = v?.id
    })

    this.itemService.createItem(this.model).subscribe({
      next: _ => {
        this.router.navigateByUrl('/items/user-item-list');
        this.toastr.success("Item created!");
      }
    });
    //tu błąd można dowalić
  }
}
