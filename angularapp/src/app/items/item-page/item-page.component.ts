import { Component, OnInit } from '@angular/core';
import { Item } from '../../_models/item';
import { ItemsService } from '../../_services/items.service';
import { CurrentItemShareService } from '../../_services/current-item-share.service';
import { AccountService } from '../../_services/account.service';
import { UserToken } from '../../_models/user-token';
import { concatMap, take } from 'rxjs';
import { MatchesService } from '../../_services/matches.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatchDialogComponent } from '../../matches/match-dialog/match-dialog.component';

@Component({
  selector: 'app-item-page',
  templateUrl: './item-page.component.html',
  styleUrls: ['./item-page.component.css']
})
export class ItemPageComponent {

  matchableItem: Item | null = null;
  userItem: Item | null = null;
  userId: number = 0;
  itemId: number = 0;

  constructor(private matchesService: MatchesService,
    private accountService: AccountService,
    protected currentItemShareService: CurrentItemShareService,
    private dialog: MatDialog) { }
    

  openMatchDialog(itemA: Item, itemB: Item) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      itemA: itemA,
      itemB: itemB
    }

    return this.dialog.open(MatchDialogComponent, dialogConfig);
  }

  ngOnInit() {
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: user => this.userId = user?.id as number
    });
    this.currentItemShareService.getItem.subscribe(item => {
      this.userItem = item;
      this.itemId = item?.id as number
    })

    this.getNextMatchable();
  }

  getNextMatchable() {
    this.matchesService.getNextMatchableItem(this.userId, this.itemId).subscribe(item => this.matchableItem = item);
  }

  sendLike() {
    this.matchesService.sendLike(this.itemId, this.matchableItem!.id)
      .subscribe(v => {
        if (v) {
          if (!this.userItem || !this.matchableItem) {/*Handle error*/ return; }
          const dialogRef = this.openMatchDialog(this.userItem, this.matchableItem);
          dialogRef.afterClosed().subscribe(data => {
            if (data as boolean) {/*Redirect to matches*/ }
            else {/*keep browsing, probably dont have to do anything*/ }     
          })
        }
        this.getNextMatchable()
      });
  }

  sendDislike() {
    this.matchesService.sendDislike(this.itemId, this.matchableItem!.id)
      .subscribe(v => this.getNextMatchable());
  }
}
