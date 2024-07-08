import { Customer } from "./customer";
import { Roles } from "./MenuItems";
import { Shop } from "./shop";

export class UserResponse{
    username:string=''; 
    email :string='';
    password:string='';
    role:Roles=Roles.None;
    customer:Customer|null=null;
    store:Shop|null=null;
    token:string|null=null;
    
}