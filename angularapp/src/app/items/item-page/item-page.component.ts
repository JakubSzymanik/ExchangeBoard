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

  constructor(private itemService: ItemsService, protected currentItemShareService: CurrentItemShareService) { }

  ngOnInit() {
    //this.currentItemShareService.getItem.subscribe(v => this.item = v);
  }
}
