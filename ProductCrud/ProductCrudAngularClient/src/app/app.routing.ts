import {Routes,RouterModule} from "@angular/router";
import { IndexComponent } from "./components/index/index.component";
import { AddComponent } from "./components/add/add.component";
import { EditComponent } from "./components/edit/edit.component";

   const routes:Routes=[
{path:'',component:IndexComponent},
{path:'index',component:IndexComponent},
{path:'add',component:AddComponent},
{path:'edit/:id',component:EditComponent}
   ];
export const routing=RouterModule.forRoot(routes);