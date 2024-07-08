import { Customer } from "./customer";
import { Item } from "./Item";

export class ShoppingCar{
    id :number=0;
    customerId:number=0; 
    customer :Customer=new Customer;
    itemId :number=0;
    item :Item=new Item;
    date :Date=new Date;
    count :number=0;

}