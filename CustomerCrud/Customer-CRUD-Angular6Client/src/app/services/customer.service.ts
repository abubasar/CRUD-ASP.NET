import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../customer.entity';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http:HttpClient) { }

  private base_url:string='http://localhost:5000/api/customer';

  get(id:number):Observable<Customer>{
    return this.http.get<Customer>(this.base_url+'/'+id);
    
  }

  getAll():Observable<Customer[]>{
    return this.http.get<Customer[]>(this.base_url);
    
  }
  delete(id:number){
    return this.http.delete(this.base_url+'/'+id);
    
  }

  create(customer:Customer){
    return this.http.post(this.base_url,customer);
    
  }

  update(customer:Customer){
    return this.http.put(this.base_url,customer);
    
  }

  
}
