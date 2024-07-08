export interface MenuItem {
    label: string;
    route: string;
    roles: Roles[];
  }
  export enum Roles {
    None,
    Admin,
    Customer,
    Store
  }
  export const menuItems: MenuItem[] = [

    { label: 'Items', route: '/item-list', roles: [Roles.Admin,Roles.Store] },
    { label: 'Customers', route: '/customer-list', roles: [Roles.Admin] },
  ];

