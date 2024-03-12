import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-animals',
  templateUrl: './animals.component.html',
  styleUrls: ['./animals.component.css']
})
export class AnimalsComponent {
@Input() animal:any
oszlopok =[
  {key:"nev", text:"Név", type:"text"},
  {key:"faj", text:"Fajta", type:"text"},
  {key:"kor", text:"Életkor", type:"number"},
]
}
