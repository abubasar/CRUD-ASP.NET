import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/customer.entity';
import { CustomerService } from 'src/app/services/customer.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.css']
})
export class CustomerDetailsComponent implements OnInit {
customer:Customer
  constructor(private customerService:CustomerService,private activatedRoute:ActivatedRoute) { }

  ngOnInit() {
    var id=this.activatedRoute.snapshot.params.id;
    this.customerService.get(id).subscribe(res=>{
      this.customer=res;
    })

  }

}
