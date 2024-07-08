import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Item } from 'src/app/models/Item';
import { ShoppingCar } from 'src/app/models/ShoppingCar';
import { UserResponse } from 'src/app/models/UserResponse';
import { ShoppingcarService } from 'src/app/services/shoppingcar.service';

@Component({
  selector: 'app-shopping-car',
  templateUrl: './shopping-car.component.html',
  styleUrls: ['./shopping-car.component.scss']
})
export class ShoppingCarComponent implements OnInit {
  User:UserResponse=new UserResponse;
  items:ShoppingCar[]=[];
  constructor(private _shoppingCarServoce:ShoppingcarService,  private snackBar: MatSnackBar, private router:Router) {
    
    this.getUserLogin();
    this.getITems()
   }

  ngOnInit(): void {
  }
  getUserLogin(){
    var userlos=localStorage.getItem('user')??'';
   
    if(userlos){
      this.User=JSON.parse(userlos)  as UserResponse;
      console.log(this.User);      
    }else {
      this.router.navigate(['/login']);
    }
  }
  getITems(){
    console.log(this.User)
    this._shoppingCarServoce.getAll( this.User.customer?.id ??0).subscribe(
      updateuser => {
        
        console.log(this.items)
        this.items=updateuser
      },
      error => {
        this.snackBar.open('Error ', 'x', {
          duration: 2000,
          horizontalPosition: 'right',
          verticalPosition: 'top',
          panelClass: ['custom-snackbar']
        });
      }
    );
  }
  OnDelete(_item:Item){
    let sp=new ShoppingCar()
    sp.customerId=this.User.customer?.id  ?? 0;
    sp.itemId=_item.id ;
    
    this._shoppingCarServoce.addItem(sp).subscribe(
      updateuser => {
       //this.Items=updateuser;
      },
      error => {
        this.snackBar.open('Error ', 'x', {
          duration: 2000,
          horizontalPosition: 'right',
          verticalPosition: 'top',
          panelClass: ['custom-snackbar']
        });
      }
    );
  }

  OnAdd(_item:Item){
    let sp=new ShoppingCar()
    sp.customerId=this.User.customer?.id  ?? 0;
    sp.itemId=_item.id ;
    
    this._shoppingCarServoce.addItem(sp).subscribe(
      updateuser => {
       //this.Items=updateuser;
      },
      error => {
        this.snackBar.open('Error ', 'x', {
          duration: 2000,
          horizontalPosition: 'right',
          verticalPosition: 'top',
          panelClass: ['custom-snackbar']
        });
      }
    );
  }
}
