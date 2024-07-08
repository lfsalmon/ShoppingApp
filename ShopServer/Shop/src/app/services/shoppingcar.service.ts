import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ShoppingCar } from '../models/ShoppingCar';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ShoppingcarService {

  private urlAPI='https://localhost:5001/api/ShoppingCar/';
  constructor(private http:HttpClient) { }

  public getAll(_idClient:number): Observable<ShoppingCar[]>{
    console.log(this.urlAPI+'getbyclient/'+_idClient+'?_id='+_idClient)

    return this.http.get<ShoppingCar[]>(this.urlAPI+'getbyclient/'+_idClient+'?_id='+_idClient)
  }
  addItem(item: ShoppingCar): Observable<ShoppingCar> {
    return this.http.post<ShoppingCar>(this.urlAPI+'updateshoppingcar', item);
  }

}
