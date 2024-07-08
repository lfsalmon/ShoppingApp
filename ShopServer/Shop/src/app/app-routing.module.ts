import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ItemListComponent } from './components/item-list/item-list.component';
import { ShopListComponent } from './components/shop-list/shop-list.component';
import { CustomerListComponent } from './components/customer-list/customer-list.component';
import { LoginComponent } from './components/login/login.component';
import { StoreHomeComponent } from './components/store-home/store-home.component';
import { ItemsComponent } from './components/items/items.component';
import { ShoppingCarComponent } from './components/shopping-car/shopping-car.component';


const routes: Routes = [  
  {path:'item-list' ,component:ItemListComponent},
  {path:'shop-list' ,component:ShopListComponent},
  {path:'all-item-list' ,component:ItemsComponent},
  {path:'customer-list' ,component:CustomerListComponent},
  {path:'store-home' ,component:StoreHomeComponent},
  {path:'login' ,component:LoginComponent},
  {path:'shopping-car' ,component:ShoppingCarComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
