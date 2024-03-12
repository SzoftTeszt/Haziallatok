import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
  private gazdak=new BehaviorSubject(null);
  constructor(private http:HttpClient) { 
    this.loadGazdak()
  }

  loadGazdak(){
    this.http.get("https://localhost:5000/api/Gazdak").subscribe(
      (res:any)=>this.gazdak.next(res)
    )
  }
  getGazdak(){
    return this.gazdak
  }
}
