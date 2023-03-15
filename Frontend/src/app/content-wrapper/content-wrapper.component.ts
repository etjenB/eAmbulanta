import { Component } from '@angular/core';
import {AuthService} from "../service/auth.service";
import {EAmbulantaServiceService} from "../service/e-ambulanta-service.service";
import {Novost} from "../models/novost.model";

@Component({
  selector: 'app-content-wrapper',
  templateUrl: './content-wrapper.component.html',
  styleUrls: ['./content-wrapper.component.css']
})
export class ContentWrapperComponent {
  novosti : Novost[] = [];

  constructor(private service : EAmbulantaServiceService) {
  }

  ngOnInit(){
    this.pozoviGetNovosti();
  }

  pozoviGetNovosti(){
    this.service.getNovosti().subscribe(
      res=>{
        this.novosti = res;
      },
      err=>{
        console.log(err);
      }
    );
  }
}
