import { Item } from "./Item";

export class ShopList{
    id :number=0;
    name:string=''; 
    state :string='';
    city :string='';
    fullAddress :string='';
    Items:Item[]=[];
}