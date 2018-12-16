import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { CustomerService } from 'src/app/services/customer.service';
import { Router, ActivatedRoute } from '@angular/router';
import { CountryService } from 'src/app/services/country.service';
import { BsDatepickerConfig } from 'ngx-bootstrap';

@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrls: ['./edit-customer.component.css']
})
export class EditCustomerComponent implements OnInit {
  countries:any[]
  customerForm:FormGroup
  bsConfig:Partial<BsDatepickerConfig>

  constructor(private formBuilder:FormBuilder,private customerService:CustomerService,
    private router:Router,private countryService:CountryService,
    private activatedRoute:ActivatedRoute) { }

  ngOnInit() {
    var id=this.activatedRoute.snapshot.params.id;
    this.customerService.get(id).subscribe(res=>{
      this.customerForm=this.formBuilder.group({
        id:res.id,
        firstName:res.firstName,
        lastName:res.lastName,
        email:res.email,
        mobileNumber:res.mobileNumber,
        gender:res.gender,
        dob:res.dob,
        address:res.address,
        countryId:res.countryId,
        isActive:res.isActive
        
        },error=>{
          console.log(error)
        });
    })
  

this.loadCountries();

  }

  loadCountries(){
    this.countryService.getAll().subscribe(res=>{
      this.countries=res
    },error=>{
      console.log(error)
    });
  }

  edit(){

    this.customerService.update(this.customerForm.value).subscribe(res=>{
      this.router.navigate([''])
    },error=>{
      console.log(error);
    })
  }

}