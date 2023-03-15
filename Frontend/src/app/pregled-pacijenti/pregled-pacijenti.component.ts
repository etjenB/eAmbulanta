import { Component } from '@angular/core';
import {EAmbulantaServiceService} from "../service/e-ambulanta-service.service";
import Swal from "sweetalert2";
import {Router} from "@angular/router";

@Component({
  selector: 'app-pregled-pacijenti',
  templateUrl: './pregled-pacijenti.component.html',
  styleUrls: ['./pregled-pacijenti.component.css']
})
export class PregledPacijentiComponent {

  Pacijenti : any;

  constructor(private service : EAmbulantaServiceService, private router : Router) {
  }

  ngOnInit(){
    this.service.getAllPacijenti().subscribe(
      res=>{
        this.Pacijenti=res;
      },
      err=>{
        console.log(err);
      }
    );
  }

  visePodatakaOPacijentu(pacijentId : string){
    Swal.fire({
      title: 'Prelazak na stranicu o pacijentu?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#d23434',
      cancelButtonColor: '#5ab23d',
      cancelButtonText: 'Odustani',
      confirmButtonText: 'Pređi na stranicu o pacijentu'
    }).then((result) => {
      if (result.isConfirmed) {
        this.router.navigate(['pacijent'], {queryParams: {pacijentId : pacijentId}});
      }
    });
  }

}
