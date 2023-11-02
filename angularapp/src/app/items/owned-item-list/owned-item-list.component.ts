import { Component, OnInit } from '@angular/core';
import { ItemsService } from '../../_services/items.service';
import { User } from '../../_models/user';
import { AccountService } from '../../_services/account.service';
import { take } from 'rxjs';
import { UserToken } from '../../_models/user-token';
import { Item } from '../../_models/item';

@Component({
  selector: 'app-user-item-list',
  templateUrl: './owned-item-list.component.html',
  styleUrls: ['./owned-item-list.component.css']
})
export class OwnedItemListComponent {

  private user: UserToken | null = null;
  protected items: Item[] = [];

  constructor(private itemService: ItemsService, private accountService: AccountService) { }

  ngOnInit(): void {

    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: user => this.user = user
    });

    if (this.user)
      this.itemService.getUserItemsByUserId(this.user.id).subscribe({
        next: items => this.items = items
      })
  }
}
