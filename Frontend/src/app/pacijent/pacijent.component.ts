import { Component } from '@angular/core';
import {EAmbulantaServiceService} from "../service/e-ambulanta-service.service";
import {ActivatedRoute, Router} from "@angular/router";
import {AuthService} from "../service/auth.service";
import {Pregled} from "../models/pregled";
import Swal from "sweetalert2";

@Component({
  selector: 'app-pacijent',
  templateUrl: './pacijent.component.html',
  styleUrls: ['./pacijent.component.css']
})
export class PacijentComponent {
  pacijentId : string;
  pacijent : any;
  prethodniTermini : Pregled[] = [];
  bolestiPacijenta:any;
  nadolazeciTretmani : any;

  constructor(public service : EAmbulantaServiceService, public router : Router, public route : ActivatedRoute, public authService : AuthService) {
  }

  ngOnInit(){
    this.route.queryParams
      .subscribe(params => {
          this.pacijentId = params.pacijentId;
        }
      );
    this.service.getPacijent(this.pacijentId).subscribe(
      res=>{
        this.pacijent = res;
      },
      err=>{
        console.log(err);
      }
    );
    this.service.getPrethodniTerminiPacijent(this.pacijentId).subscribe(
      res => {
        this.prethodniTermini = res;
      },
      err => {
        console.log(err);
      }
    );
    this.getBolestiPacijenta();
    this.getNadolazeciTretmani();
  }

  getBolestiPacijenta(){
    this.service.getBolestiZaPacijenta(this.pacijentId).subscribe(
      res=>{
        this.bolestiPacijenta=res;
      },
      err=>{
        console.log(err);
      }
    );
  }

  otvoriDodajOboljenje(){
    let naziv = "";
    let opis = "";
    let icdKod = "";
    Swal.fire({
      title: 'Dodaj oboljenje',
      html:
        '<input id="swal-input1" class="swal2-input" placeholder="Naziv bolesti">' +
        '<input id="swal-input2" class="swal2-input" placeholder="Opis bolesti">' +
        '<input id="swal-input3" class="swal2-input" placeholder="ICD Kod za bolest">',
      focusConfirm: false,
      preConfirm: () => {
        const input1 = (document.getElementById('swal-input1') as HTMLInputElement).value;
        const input2 = (document.getElementById('swal-input2') as HTMLInputElement).value;
        const input3 = (document.getElementById('swal-input3') as HTMLInputElement).value;
        return [input1, input2, input3];
      }
    }).then((result) => {
      if (result.isConfirmed) {
        const [input1, input2, input3] = result.value as [string, string, string];
        if (input1==""||input2==""||input3==""){
          Swal.fire(
            'Greška',
            'Potrebno popuniti sva polja!',
            'warning'
          );
          return;
        }
        naziv = input1;
        opis = input2;
        icdKod = input3;
        this.service.addBolest(this.pacijentId, naziv, opis, icdKod).subscribe(
          res=>{
            Swal.fire({
              position: 'top-end',
              icon: 'success',
              title: 'Uspješno dodana bolest!',
              showConfirmButton: false,
              timer: 2500
            });
            console.log(this.pacijentId);
            this.getBolestiPacijenta();
          },
          err=>{
            console.log(err);
          }
        );
      }
    });
  }

  ukloniOboljenje(bolestId:any){
    this.service.deleteBolest(bolestId).subscribe(
      res=>{
        Swal.fire({
          position: 'top-end',
          icon: 'success',
          title: 'Uspješno uklonjeno oboljenje!',
          showConfirmButton: false,
          timer: 2500
        });
        this.getBolestiPacijenta();
      },
      err=>{
        console.log(err);
      }
    );
  }

  getNadolazeciTretmani(){
    this.service.getNadolazeciTretmani(this.pacijentId).subscribe(
      res=>{
        this.nadolazeciTretmani = res;
      },
      err=>{
        console.log(err);
      }
    );
  }

  otvoriDodajTretman(){
    let opis = "";
    let napomena = "";
    Swal.fire({
      title: 'Dodaj tretman',
      html:
        '<input id="swal-input1" class="swal2-input" placeholder="Opis tretmana">' +
        '<input id="swal-input2" class="swal2-input" placeholder="Napomena za tretman">',
      focusConfirm: false,
      preConfirm: () => {
        const input1 = (document.getElementById('swal-input1') as HTMLInputElement).value;
        const input2 = (document.getElementById('swal-input2') as HTMLInputElement).value;
        return [input1, input2];
      }
    }).then((result) => {
      if (result.isConfirmed) {
        const [input1, input2] = result.value as [string, string];
        if (input1==""||input2==""){
          Swal.fire(
            'Greška',
            'Potrebno popuniti sva polja!',
            'warning'
          );
          return;
        }
        opis = input1;
        napomena = input2;
        this.service.addTretman(this.pacijentId, opis, napomena).subscribe(
          res=>{
            Swal.fire({
              position: 'top-end',
              icon: 'success',
              title: 'Uspješno dodan tretman!',
              showConfirmButton: false,
              timer: 2500
            });
            this.getNadolazeciTretmani();
          },
          err=>{
            console.log(err);
          }
        );
      }
    });
  }

  ukloniTretman(tretmanId:any){
    this.service.deleteTretman(tretmanId).subscribe(
      res=>{
        Swal.fire({
          position: 'top-end',
          icon: 'success',
          title: 'Uspješno uklonjen tretman!',
          showConfirmButton: false,
          timer: 2500
        });
        this.getNadolazeciTretmani();
      },
      err=>{
        console.log(err);
      }
    );
  }

  obaviTretman(tretmanId:any){
    this.service.obaviTretman(tretmanId).subscribe(
      res=>{
        Swal.fire({
          position: 'top-end',
          icon: 'success',
          title: 'Uspješno obavljen tretman!',
          showConfirmButton: false,
          timer: 2500
        });
        this.getNadolazeciTretmani();
      },
      err=>{
        console.log(err);
      }
    );
  }

}
