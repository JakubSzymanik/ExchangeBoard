import { Component, OnInit } from '@angular/core';
import { ItemsService } from '../../_services/items.service';
import { AccountService } from '../../_services/account.service';
import { take } from 'rxjs';
import { UserToken } from '../../_models/user-token';
import { Item } from '../../_models/item';
import { Router } from '@angular/router';
import { CurrentItemShareService } from '../../_services/current-item-share.service';

@Component({
  selector: 'app-user-item-list',
  templateUrl: './owned-item-list.component.html',
  styleUrls: ['./owned-item-list.component.css']
})
export class OwnedItemListComponent {
  private user: UserToken | null = null;
  protected items: Item[] = [];
  protected addtext: string = 'Add';
  protected addimgpath: string = '../assets/images/Plus.png';

  constructor(private itemService: ItemsService, private accountService: AccountService, private router: Router, private itemShareService: CurrentItemShareService) { }

  ngOnInit(): void {

    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: user => this.user = user
    });

    if (this.user)
      this.itemService.getUserItemsByUserId(this.user.id).subscribe({
        next: items => this.items = items
      })
  }

  onItemClick(item: Item) {
    this.itemShareService.setItem(item);
    this.router.navigateByUrl('items/item-page')
  }

  onAddClick() {
    this.router.navigateByUrl('items/add-item');
  }
}
