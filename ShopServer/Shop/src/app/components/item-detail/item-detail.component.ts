import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Item } from 'src/app/models/Item';


@Component({
  selector: 'app-item-detail',
  templateUrl: './item-detail.component.html',
  styleUrls: ['./item-detail.component.scss']
})
export class ItemDetailComponent implements OnInit {
  @Input() Item:Item=new Item();
  @Input() IsShoppingcar:Boolean=false;
  @Input() Count:number=0;
  @Output() deleteItem:EventEmitter<Item>= new EventEmitter();
  @Output() AddItem:EventEmitter<Item>= new EventEmitter();
  constructor() { }

  ngOnInit(): void {
    console.log(this.Item)
  }
  Delete(_item:Item){
    this.deleteItem.emit(this.Item);
  }
  Add(_item:Item){
    this.deleteItem.emit(this.Item);
  }
}
