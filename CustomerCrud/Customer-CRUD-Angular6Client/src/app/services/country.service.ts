import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  constructor(private http:HttpClient) { }

  private base_url:string='http://localhost:5000/api/country';

  getAll():Observable<any>{
    return this.http.get<any>(this.base_url);
    
  }
}
