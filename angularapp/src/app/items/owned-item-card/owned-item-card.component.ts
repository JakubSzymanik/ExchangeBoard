import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Item } from '../../_models/item';

@Component({
  selector: 'app-owned-item-card',
  templateUrl: './owned-item-card.component.html',
  styleUrls: ['./owned-item-card.component.css']
})
export class OwnedItemCardComponent {
  @Input() item: Item | null = null;
  @Output() itemClickedEvent = new EventEmitter<Item>();

  constructor() { }

  itemClicked() {
    this.itemClickedEvent.emit(this.item ? this.item : undefined);
  }
}
