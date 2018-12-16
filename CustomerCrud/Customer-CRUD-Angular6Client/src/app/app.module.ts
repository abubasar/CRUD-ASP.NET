import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import{RouterModule} from '@angular/router';
import {HttpClientModule} from '@angular/common/http';
import{FormsModule, ReactiveFormsModule} from '@angular/forms';
import {BsDatepickerModule,BsDropdownModule} from 'ngx-bootstrap';


import { AppComponent } from './app.component';
import { CustomerListComponent } from './components/customer-list/customer-list.component';
import { AddCustomerComponent } from './components/add-customer/add-customer.component';
import { EditCustomerComponent } from './components/edit-customer/edit-customer.component';
import { CustomerService } from './services/customer.service';
import { routing } from './app.routing';
import { CountryService } from './services/country.service';
import { CustomerDetailsComponent } from './components/customer-details/customer-details.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomerListComponent,
    AddCustomerComponent,
    EditCustomerComponent,
    CustomerDetailsComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    routing,
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot()
  ],
  providers: [
    CustomerService,
    CountryService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
