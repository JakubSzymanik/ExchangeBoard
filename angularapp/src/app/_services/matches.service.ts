import { Injectable } from '@angular/core';
import { Item } from '../_models/item';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MatchesService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getMatchableItems(userId: number, itemId: number) {
    return this.http.get<Item[]>(this.baseUrl + 'matches/getmatchableitems/' + userId.toString() + "/" + itemId.toString());
  }

  getNextMatchableItem(userId: number, itemId: number) {
    return this.http.get<Item>(this.baseUrl + 'matches/getnextmatchable/' + userId.toString() + "/" + itemId.toString());
  }

  sendLike(itemId: number, targetItemId: number) {
    return this.http.post<boolean>(this.baseUrl + 'matches/sendlike/' + itemId + '/' + targetItemId, {});
  }

  sendDislike(itemId: number, targetItemId: number) {
    return this.http.post(this.baseUrl + 'matches/senddislike/' + itemId + '/' + targetItemId, {});
  }
}
