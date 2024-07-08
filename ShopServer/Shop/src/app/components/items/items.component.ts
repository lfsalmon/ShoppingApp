import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Item } from 'src/app/models/Item';
import { ShoppingCar } from 'src/app/models/ShoppingCar';
import { UserResponse } from 'src/app/models/UserResponse';
import { ItemService } from 'src/app/services/item.service';
import { ShoppingcarService } from 'src/app/services/shoppingcar.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.scss']
})
export class ItemsComponent implements OnInit 
{

  public Items:Item[]=[];
  User:UserResponse=new UserResponse;
  
  constructor(private _shoppingCarServoce:ShoppingcarService,
    private router:Router,
    private _ItemServicece:ItemService,
    private snackBar: MatSnackBar
  ) {
    this.getITems();
    this.getUserLogin();
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
    this._ItemServicece.getAll().subscribe(
      updateuser => {
       this.Items=updateuser;
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
  ngOnInit(): void {
    
  }

}
