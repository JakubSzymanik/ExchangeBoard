import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { User } from '../_models/user';
import { AccountService } from './account.service';
import { Item } from '../_models/item';


@Injectable({
  providedIn: 'root'
})
export class ItemsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getItems() {
    return this.http.get<Item[]>(this.baseUrl + 'items/getitems');
  }

  getUserItemsByUserId(id: number) {
    return this.http.get<Item[]>(this.baseUrl + 'items/getuseritems/' + id.toString());
  }

  createItem(item: Item) {
    return this.http.post<Item>(this.baseUrl + 'items/createitem', item);
  }
}
