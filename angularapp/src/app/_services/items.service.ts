import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Item } from '../_models/item';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getItem(itemId: number) {
    return this.http.get<Item>(this.baseUrl + 'items/getitembyid/' + itemId.toString())
  }

  //gets all items
  getItems() {
    return this.http.get<Item[]>(this.baseUrl + 'items/getitems');
  }

  getUserItemsByUserId(userId: number) {
    return this.http.get<Item[]>(this.baseUrl + 'items/getuseritems/' + userId.toString());
  }

  createItem(item: Item) {
    return this.http.post<Item>(this.baseUrl + 'items/createitem', item);
  }

  getMatchableItems(userId: number, itemId: number) {
    return this.http.get<Item[]>(this.baseUrl + 'items/getmatchableitems/' + userId.toString() + "/" + itemId.toString());
  }
}
