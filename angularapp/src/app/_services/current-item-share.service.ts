import { Injectable } from '@angular/core';
import { Item } from '../_models/item';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CurrentItemShareService {

  private item: BehaviorSubject<Item | null> = new BehaviorSubject<Item | null>(null);
  getItem = this.item.asObservable();

  constructor() { }

  setItem(item: Item) {
    this.item.next(item);
  }
}
