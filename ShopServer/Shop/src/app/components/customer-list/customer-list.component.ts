import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTable } from '@angular/material/table';
import { Customer } from 'src/app/models/customer';
import { CustomerService } from 'src/app/services/customer.service';
import { CustomerDialogComponent } from '../customer-dialog/customer-dialog.component';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss']
})
export class CustomerListComponent implements OnInit {
  @ViewChild(MatTable) table!: MatTable<Customer>;
  dataSource:Customer[]=[];
  displayedColumns: string[] = ['name', 'lastName',"actions"];
  
  constructor(
    public dialog: MatDialog,
    private _customerService: CustomerService,
    private snackBar: MatSnackBar
  ) {
    
  }

  ngOnInit(): void {
    this.loadItems();
  }

  loadItems(): void {
    this._customerService.getAll().subscribe(
      customers => {
        this.dataSource = customers;
        console.log(customers);
        this.table.renderRows();
      },
      error => {
        this.snackBar.open('Error al obtener clientes', 'x', {
          duration: 3000,
          horizontalPosition: 'right',
          verticalPosition: 'top'
        });
      }
    );
  }
  editItem(_customer: Customer): void {
    const dialogRef = this.dialog.open(CustomerDialogComponent, {
      width: '500px',
      data: { ..._customer }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this._customerService.updateItem(result).subscribe(
          customshop => {
            this.loadItems();
          },
          error => {
            this.snackBar.open('Error actualizar clientes', 'x', {
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
    const dialogRef = this.dialog.open(CustomerDialogComponent, {
      width: '500px',
      data: new Customer
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this._customerService.addItem(result).subscribe(
          newcustomer => {
            this.loadItems();
          },
          error => {
            this.snackBar.open('Error agregar empleados', 'x', {
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
