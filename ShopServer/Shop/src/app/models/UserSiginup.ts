import { Customer } from "./customer";
import { Shop } from "./shop";

export class UserSiginup{
    Username:string=''; 
    Email :string='';
    Password:string='';
    Role:number=0;
    Customer:Customer|null=null;
    Store:Shop|null=null;

}



