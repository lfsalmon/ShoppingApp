import { Shop } from "./shop";

export class Item{
    id :number=0;
    code:string=''; 
    name :string='';
    description :string='';
    cost :number=0;
    count:number=0;
    image :string=''; 
    shopId :number=0;
    shop: Shop = new Shop; 
}