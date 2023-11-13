import { Component, OnInit } from '@angular/core';
import { Item } from '../../_models/item';
import { ItemsService } from '../../_services/items.service';
import { CurrentItemShareService } from '../../_services/current-item-share.service';

@Component({
  selector: 'app-item-page',
  templateUrl: './item-page.component.html',
  styleUrls: ['./item-page.component.css']
})
export class ItemPageComponent {
  protected item: Item | null = null;

  constructor(private itemService: ItemsService, private currentItemShareService: CurrentItemShareService) { }

  onNgInit() {
    this.currentItemShareService.getItem.subscribe({
      next: v => this.item = v
    })
  }
}
