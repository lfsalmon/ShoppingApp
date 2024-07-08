import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Item } from '../models/Item';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
 
  private urlAPI='https://localhost:5001/api/Item/';
  constructor(private http:HttpClient) { }

  public getAll(): Observable<Item[]>{
    return this.http.get<Item[]>(this.urlAPI+'all')
  }
  addItem(item: Item): Observable<Item> {
    return this.http.post<Item>(this.urlAPI+'add', item);
  }

  updateItem(item: Item): Observable<Item> {
    return this.http.put<Item>(`${this.urlAPI}update`, item);
  }
}
