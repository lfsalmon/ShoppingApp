import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Shop } from '../models/shop';
import { HttpClient } from '@angular/common/http';
import { ShopList } from '../models/shop-list';
@Injectable({
  providedIn: 'root'
})
export class ShopService {

  
  private urlAPI='https://localhost:5001/api/Shop/';
  constructor(private http:HttpClient) { }

  public getAll(): Observable<ShopList[]>{
    return this.http.get<ShopList[]>(this.urlAPI+'all')
  }
  addItem(item: Shop): Observable<Shop> {
    return this.http.post<Shop>(this.urlAPI+'add', item);
  }

  updateItem(item: Shop): Observable<Shop> {
    return this.http.put<Shop>(`${this.urlAPI}update`, item);
  }
}
