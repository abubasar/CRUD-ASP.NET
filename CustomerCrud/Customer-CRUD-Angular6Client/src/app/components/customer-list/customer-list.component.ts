import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/customer.entity';
import { CustomerService } from 'src/app/services/customer.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
customers:Customer[]
  constructor(private customerService:CustomerService,private router:Router) { }

  ngOnInit() {
    this.loadData();
  }

  loadData(){
this.customerService.getAll().subscribe(res=>{
  this.customers=res;
  console.log(this.customers);

},error=>{
  console.log(error)
});
  }

  edit(id:number){
this.router.navigate(['/edit/'+id]);
  }
  delete(id:number){
var result=confirm("Are You sure to delete this customer");
if(result){
  this.customerService.delete(id).subscribe(res=>{
    this.router.navigate([''])
  },error=>{
    console.log(error);
  })
}
  }
  display(id:number){
    this.router.navigate(['/details/'+id]);
  }

}
