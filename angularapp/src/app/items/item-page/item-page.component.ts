import { Component, OnInit } from '@angular/core';
import { Item } from '../../_models/item';
import { ItemsService } from '../../_services/items.service';
import { CurrentItemShareService } from '../../_services/current-item-share.service';
import { AccountService } from '../../_services/account.service';
import { UserToken } from '../../_models/user-token';
import { concatMap, take } from 'rxjs';
import { MatchesService } from '../../_services/matches.service';

@Component({
  selector: 'app-item-page',
  templateUrl: './item-page.component.html',
  styleUrls: ['./item-page.component.css']
})
export class ItemPageComponent {

  constructor(private matchesService: MatchesService, private accountService: AccountService, protected currentItemShareService: CurrentItemShareService) { }

  matchableItem: Item | null = null;
  userId: number = 0;
  itemId: number = 0;

  ngOnInit() {
    //this.currentItemShareService.getItem.subscribe(v => this.item = v);
    
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: user => this.userId = user?.id as number
    });
    this.currentItemShareService.getItem.subscribe(item => this.itemId = item?.id as number)

    this.getNextMatchable();
  }

  getNextMatchable() {
    this.matchesService.getNextMatchableItem(this.userId, this.itemId).subscribe(item => this.matchableItem = item);
  }

  sendLike() {
    console.log("item page: like sent");
    this.matchesService.sendLike(this.itemId, this.matchableItem!.id)
      .subscribe(v => this.getNextMatchable());
    //handle match
  }

  sendDislike() {
    this.matchesService.sendDislike(this.itemId, this.matchableItem!.id)
      .subscribe(v => this.getNextMatchable());
  }
}
