import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';

import { Item } from 'src/app/models/Item';
import { ItemDialogComponent } from '../item-dialog/item-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { ItemService } from 'src/app/services/item.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ShopService } from 'src/app/services/shop.service';
import { Shop } from 'src/app/models/shop';
import { ShopList } from 'src/app/models/shop-list';


@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.scss'],
 
})
export class ItemListComponent implements OnInit  {
  SelectedShop:number =0;
  Shops:ShopList[]=[];
  @ViewChild(MatTable) table!: MatTable<Item>;
  
  dataSource:Item[]=[];
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns: string[] = [ 'name','code', 'description', 'cost', 'actions'];

  constructor(
    public dialog: MatDialog,
    private itemService: ItemService,
    private _shopService: ShopService,
    private snackBar: MatSnackBar
  ) {
    this.loadShops();  
    this.loadItems();
  }
  loadShops():void{
    this._shopService.getAll().subscribe(
      shops => {
        this.Shops=shops;
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
  ngOnInit(): void {
    this.loadItems();
  }

  loadItems(): void {
    this.itemService.getAll().subscribe(
      items => {
        this.dataSource = items;
        this.table.renderRows();
      },
      error => {
        this.snackBar.open('Error al obtener articulos', 'x', {
          duration: 3000,
          horizontalPosition: 'right',
          verticalPosition: 'top'
        });
      }
    );
  }

  editItem(item: Item): void {

    if(this.SelectedShop!=0){
      const dialogRef = this.dialog.open(ItemDialogComponent, {
        width: '500px',
        data: { ...item }
      });
  
      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          this.itemService.updateItem(result).subscribe(
            updatedItem => {
              this.loadItems();
            },
            error => {
              this.snackBar.open('Error editando articulo', 'x', {
                duration: 2000,
                horizontalPosition: 'right',
                verticalPosition: 'top',
                panelClass: ['custom-snackbar']
              });
            }
          );
        }
      });
    }
    else {
      this.snackBar.open('Favor de seleccionar una tienda', 'x', {
        duration: 1000,
        horizontalPosition: 'right',
        verticalPosition: 'top',
        panelClass: ['custom-snackbar']
      });
    }
  }
  openAddDialog(): void {
    if(this.SelectedShop!=0)
    {
      const dialogRef = this.dialog.open(ItemDialogComponent, {
        width: '500px',
        data: { id: undefined, name: '', description: '', cost: 0, shopid:this.SelectedShop,shop:this.Shops.find(x=>x.id==this.SelectedShop) }
      });
  
      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          this.itemService.addItem(result).subscribe(
            newItem => {
              console.log(result);
              this.loadItems();
            },
            error => {
              this.snackBar.open('Error adding item', 'Close', {
                duration: 2000,
                horizontalPosition: 'right',
                verticalPosition: 'top',
                panelClass: ['custom-snackbar']
              });
            }
          );
        }
      });
    }else {
      this.snackBar.open('Favor de seleccionar una tienda', 'x', {
        duration: 1000,
        horizontalPosition: 'right',
        verticalPosition: 'top',
        panelClass: ['custom-snackbar']
      });
    }
    
  }

  

}
