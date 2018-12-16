import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductService } from 'src/app/services/product.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
productForm:FormGroup
  constructor(private formBuilder:FormBuilder,
    private productService:ProductService
    ,private router:Router) { }

  ngOnInit() {
    this.productForm=this.formBuilder.group({

name:['',Validators.required],
price:[0,Validators.required],
quantity:[0,Validators.required]  
    });
  }

  save(){
this.productService.create(this.productForm.value).subscribe(
  res=>{
this.router.navigate(['']);
  },error=>{
    alert(error);

  }
);
  }

}
