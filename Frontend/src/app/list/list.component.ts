import { Component, OnDestroy } from '@angular/core';
import { BaseService } from '../base.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnDestroy{
  gazdak:any
  feliratkozas = new Subscription()

  constructor(private base:BaseService){
    this.feliratkozas=this.base.getGazdak().subscribe(
      (res)=>{
        this.gazdak=res
        if (this.gazdak)
          for (let i = 0; i < this.gazdak.length; i++) 
            this.gazdak[i].nyitva=false         
        
      }
    )
  }

  ngOnDestroy(): void {
      this.feliratkozas.unsubscribe()
  }
}
