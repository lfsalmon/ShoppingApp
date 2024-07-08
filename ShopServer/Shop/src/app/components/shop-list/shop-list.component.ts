import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTable } from '@angular/material/table';
import { Shop } from 'src/app/models/shop';
import { ShopService } from 'src/app/services/shop.service';
import { ShopDialogComponent } from '../shop-dialog/shop-dialog.component';
import { ShopList } from 'src/app/models/shop-list';

@Component({
  selector: 'app-shop-list',
  templateUrl: './shop-list.component.html',
  styleUrls: ['./shop-list.component.scss']
})
export class ShopListComponent implements OnInit {
  @ViewChild(MatTable) table!: MatTable<ShopList>;
  dataSource:ShopList[]=[];
  displayedColumns: string[] = ['name', 'state', 'city','fullAddress',"actions"];
  
  constructor(
    public dialog: MatDialog,
    private _shopService: ShopService,
    private snackBar: MatSnackBar
  ) {
    
  }

  ngOnInit(): void {
    this.loadItems();
  }

  loadItems(): void {
    this._shopService.getAll().subscribe(
      shops => {
        this.dataSource = shops;
        console.log(shops);
        this.table.renderRows();
      },
      error => {
        this.snackBar.open('Error al obtener tiendas', 'x', {
          duration: 3000,
          horizontalPosition: 'right',
          verticalPosition: 'top'
        });
      }
    );
  }
  editItem(_shop: Shop): void {
    const dialogRef = this.dialog.open(ShopDialogComponent, {
      width: '500px',
      data: { ..._shop }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this._shopService.updateItem(result).subscribe(
          updatedshop => { 
            this.loadItems();
          },
          error => {
            this.snackBar.open('Error updating item', 'Close', {
              duration: 3000,
              horizontalPosition: 'right',
              verticalPosition: 'top',
              panelClass: ['custom-snackbar']
            });
          }
        );
      }
    });
  }
  openAddDialog(): void {
    const dialogRef = this.dialog.open(ShopDialogComponent, {
      width: '500px',
      data: { id: undefined, name: '', description: '', cost: 0 }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this._shopService.addItem(result).subscribe(
          newshop => {
            this.loadItems();
          },
          error => {
            this.snackBar.open('Error adding item', 'Close', {
              duration: 3000,
              horizontalPosition: 'right',
              verticalPosition: 'top',
              panelClass: ['custom-snackbar']
            });
          }
        );
      }
    });
  }

}
