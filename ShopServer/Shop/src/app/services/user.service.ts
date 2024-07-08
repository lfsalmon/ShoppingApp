import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserResponse } from '../models/UserResponse';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { UserSiginup } from '../models/UserSiginup';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  currentUserLoginOn:BehaviorSubject<boolean>= new BehaviorSubject<boolean>(false);
  currentUserData:BehaviorSubject<UserResponse>= new BehaviorSubject<UserResponse>(new UserResponse);


  private urlAPI='https://localhost:5001/api/User/';
  constructor(private http:HttpClient) { }


  Siginup(item: UserSiginup): Observable<UserResponse> {
    return this.http.post<UserResponse>(this.urlAPI+'siginup', item);
  }

  Login(item: UserSiginup): Observable<UserResponse> {
    return this.http.post<UserResponse>(this.urlAPI+'login', item).pipe(
      tap((userData:UserResponse)=>{
        this.currentUserLoginOn.next(true);
        this.currentUserData.next(userData);
      })
    );
  }

  logout():void  {
    this.currentUserLoginOn.next(false);
    this.currentUserData.next(new UserResponse);
  }
  get getUserData(): Observable<UserResponse>{
    return this.currentUserData.asObservable();
  }

  get getUserLoginOn(): Observable<boolean>{
    return this.currentUserLoginOn.asObservable();
  } 
}
