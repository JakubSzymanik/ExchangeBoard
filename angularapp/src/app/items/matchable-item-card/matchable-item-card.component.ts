import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Item } from '../../_models/item';

@Component({
  selector: 'app-matchable-item-card',
  templateUrl: './matchable-item-card.component.html',
  styleUrls: ['./matchable-item-card.component.css']
})
export class MatchableItemCardComponent {
  @Input() item: Item | null = null;
  @Output() likeClickedEvent = new EventEmitter<Item>();
  @Output() dislikeClickedEvent = new EventEmitter<Item>();

  sendLike() {
    this.likeClickedEvent.emit(this.item ? this.item : undefined);
  }

  sendDislike() {
    this.dislikeClickedEvent.emit(this.item ? this.item : undefined);
  }
}
