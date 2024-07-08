import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Customer } from 'src/app/models/customer';

import { ShopList } from 'src/app/models/shop-list';
import { CustomerService } from 'src/app/services/customer.service';
import { MenuItem,menuItems,Roles } from 'src/app/models/MenuItems';
import { UserResponse } from 'src/app/models/UserResponse';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { Subscription } from 'rxjs';



@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit,OnDestroy{
  public customers:Customer[]=[];
  public menuItems: MenuItem[]=[];
  public Stores:ShopList[]=[];
  public userRole: Roles=Roles.None;
  public userloginOn:boolean=false;
  public CustomerRole:Roles=Roles.Customer;
  private loginSubscription: Subscription|null=null;
  constructor(  private _customerService: CustomerService,
                private _loginService: UserService,
                private router:Router,
                private snackBar: MatSnackBar,
  ) 
  {
  }
 
  ngOnDestroy() {
    this.loginSubscription?.unsubscribe();
  }
  
  ngOnInit(): void {
    this.getMenu();
    this.loginSubscription=this._loginService.getUserLoginOn.subscribe({
      next:(userloginOn)=>{
        this.userloginOn=userloginOn;
        this.getMenu()
      }
    });
   
   
  }

  getMenu(){
    var userlos=localStorage.getItem('user')??'';
    console.log(userlos)
    if(userlos){
      var user=JSON.parse(userlos)  as UserResponse;
      console.log(user);
      this.userRole=user.role;
      this.menuItems = menuItems.filter(item => item.roles.includes(user.role));
      if(user.token)
        this.userloginOn=true
      console.log(this.userloginOn)
    }
  }
  logout(){
    localStorage.setItem('user','');
    this.router.navigate(['/login']);
    this._loginService.logout();
  }

}
