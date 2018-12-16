import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CustomerService } from 'src/app/services/customer.service';
import { Router } from '@angular/router';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { CountryService } from 'src/app/services/country.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent implements OnInit {
  countries:any[]
  customerForm:FormGroup
  bsConfig:Partial<BsDatepickerConfig>

  constructor(private formBuilder:FormBuilder,private customerService:CustomerService,private router:Router,private countryService:CountryService) { }

  ngOnInit() {
    this.customerForm=this.formBuilder.group({
firstName:['',Validators.required],
lastName:['',Validators.required],
email:['',Validators.required],
mobileNumber:['',Validators.required],
gender:['',Validators.required],
dob:null,
address:['',Validators.required],
countryId:1,
isActive:false

});

this.loadCountries();

  }

  loadCountries(){
    this.countryService.getAll().subscribe(res=>{
      this.countries=res
    },error=>{
      console.log(error)
    });
  }

  save(){
    this.customerService.create(this.customerForm.value).subscribe(res=>{
      this.router.navigate([''])
    },error=>{
      console.log(error);
    })
  }

}
