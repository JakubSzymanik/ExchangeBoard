import { Component, Input } from '@angular/core';
import { Item } from '../../_models/item';

@Component({
  selector: 'app-matchable-item-card',
  templateUrl: './matchable-item-card.component.html',
  styleUrls: ['./matchable-item-card.component.css']
})
export class MatchableItemCardComponent {
  @Input() item: Item | null = null;

  
}
