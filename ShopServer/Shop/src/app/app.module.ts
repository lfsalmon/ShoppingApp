import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './components/header/header.component';
import { ItemsComponent } from './components/items/items.component';
import { ItemDetailComponent } from './components/item-detail/item-detail.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { ItemListComponent } from './components/item-list/item-list.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import {HttpClientModule} from '@angular/common/http';
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import { ItemDialogComponent } from './components/item-dialog/item-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import {MatToolbarModule} from '@angular/material/toolbar';
import { ShopListComponent } from './components/shop-list/shop-list.component';
import { ShopDialogComponent } from './components/shop-dialog/shop-dialog.component';
import { MatSelectModule } from '@angular/material/select';
import { CustomerListComponent } from './components/customer-list/customer-list.component';
import { CustomerDialogComponent } from './components/customer-dialog/customer-dialog.component';
import {MatBadgeModule} from '@angular/material/badge'
import {MatMenuModule} from '@angular/material/menu';
import { LoginComponent } from './components/login/login.component';
import { MatCardModule } from '@angular/material/card';
import { ReactiveFormsModule } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { StoreHomeComponent } from './components/store-home/store-home.component';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { ShoppingCarComponent } from './components/shopping-car/shopping-car.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ItemsComponent,
    ItemDetailComponent,
    ItemListComponent,
    ItemDialogComponent,
    ShopListComponent,
    ShopDialogComponent,
    CustomerListComponent,
    CustomerDialogComponent,
    LoginComponent,
    StoreHomeComponent,
    ShoppingCarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSlideToggleModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatButtonModule, 
    MatDividerModule, 
    MatIconModule,
    MatDialogModule,
    HttpClientModule,
    MatFormFieldModule,
    MatInputModule,
    MatToolbarModule,
    MatSnackBarModule,
    MatSelectModule,
    MatBadgeModule,
    MatMenuModule,
    FormsModule,
    MatCardModule,
    ReactiveFormsModule
  ],
  providers: [CookieService,[{provide: LocationStrategy, useClass: HashLocationStrategy}]],
  bootstrap: [AppComponent]
})
export class AppModule { }
