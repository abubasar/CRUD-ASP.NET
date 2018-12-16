import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http"
import { Observable } from "rxjs";
import { Product } from "../entities/product.entity";

@Injectable({
    providedIn: 'root'
})
export class ProductService{
    private  BASE_URL:string='http://localhost:5000/api/Product/';

constructor(private http:HttpClient){}
get(id:number):Observable<Product>{
    return this.http.get<Product>(this.BASE_URL+'product/'+id);
}
getAll():Observable<Product[]>{
    return this.http.get<Product[]>(this.BASE_URL+'products');
}
delete(id:number){
    return this.http.delete(this.BASE_URL+'delete/'+id);
}

create(product:Product){
    return this.http.post(this.BASE_URL+'create',product);
}

update(product:Product){
    return this.http.put(this.BASE_URL+'update',product);
}

}

