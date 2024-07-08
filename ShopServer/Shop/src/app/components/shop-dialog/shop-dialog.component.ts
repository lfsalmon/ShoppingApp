import { Component,Inject} from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Shop } from 'src/app/models/shop';

@Component({
  selector: 'app-shop-dialog',
  templateUrl: './shop-dialog.component.html',
  styleUrls: ['./shop-dialog.component.scss']
})
export class ShopDialogComponent {
  isEditMode: boolean=false;


  constructor(
    public dialogRef: MatDialogRef<ShopDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Shop) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
  save(): void {
    this.dialogRef.close(this.data);
  }

}
