import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from '../models/customer';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserResponse } from '../models/UserResponse';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  
  private urlAPI='https://localhost:5001/api/Customer/';
  constructor(private http:HttpClient) { }

  public getAll(): Observable<Customer[]>{
    return this.http.get<Customer[]>(this.urlAPI+'all')
  }
  addItem(item: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.urlAPI+'add', item);
  }

  updateItem(item: Customer): Observable<Customer> {
    return this.http.put<Customer>(`${this.urlAPI}update`, item);
  }
}  
