import { CustomerListComponent } from "./components/customer-list/customer-list.component";
import {Routes, RouterModule} from '@angular/router';
import { AddCustomerComponent } from "./components/add-customer/add-customer.component";
import { EditCustomerComponent } from "./components/edit-customer/edit-customer.component";
import { CustomerDetailsComponent } from "./components/customer-details/customer-details.component";
const routes:Routes=[
    { path: '', component: CustomerListComponent },
    {path:'add',component:AddCustomerComponent},
    {path:'edit/:id',component:EditCustomerComponent},
    {path:'details/:id',component:CustomerDetailsComponent}

]

export const routing=RouterModule.forRoot(routes);