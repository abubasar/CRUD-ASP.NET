import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/app/entities/product.entity';
import { Router } from '@angular/router';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
products:Product[]
  constructor(private productService:ProductService
    ,private router:Router) { }

  ngOnInit() {
   
  this.loadData();
  }

  loadData(){
    this.productService.getAll().subscribe(
      response=>{
       
        this.products=response;
      },error=>{
        alert("fail");
      });
  }

  edit(id:number){
    this.router.navigate(['/edit/'+id]);
  }

  delete(id:number){
    var result=confirm('Are you sure to delete this product?');
    if(result){
      this.productService.delete(id).subscribe(
        res =>{
          this.loadData();
        },error=>{
          alert(error);
        }
      )
    }
  }

}
