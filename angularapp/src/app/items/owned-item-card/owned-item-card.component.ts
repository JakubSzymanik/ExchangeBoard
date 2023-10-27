import { Component, Input } from '@angular/core';
import { Item } from '../../_models/item';

@Component({
  selector: 'app-owned-item-card',
  templateUrl: './owned-item-card.component.html',
  styleUrls: ['./owned-item-card.component.css']
})
export class OwnedItemCardComponent {
  @Input() item: Item | undefined;

  constructor() { }
}
