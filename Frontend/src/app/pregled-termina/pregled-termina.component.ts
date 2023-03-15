import { Component } from '@angular/core';
import {Pregled} from "../models/pregled";
import {AuthService} from "../service/auth.service";
import {EAmbulantaServiceService} from "../service/e-ambulanta-service.service";
import Swal from "sweetalert2";
import {Router} from "@angular/router";

@Component({
  selector: 'app-pregled-termina',
  templateUrl: './pregled-termina.component.html',
  styleUrls: ['./pregled-termina.component.css']
})
export class PregledTerminaComponent {
  terminiKojiCekajuNaOdobrenjeDoktor : Pregled[] = [];
  terminiDanas : Pregled[] = [];
  prethodniTerminiDoktor : Pregled[] = [];
  prethodniTerminiPacijent : Pregled[] = [];
  bolestiPacijenta : any;
  nadolazeciTretmani : any;
  dijagnoza : any = "";
  terapija : any = "";

  constructor(public authService : AuthService, public service : EAmbulantaServiceService, public router : Router) {
  }

  ngOnInit(){
    this.pozivTerminiKojiCekajuNaOdobrenjeDoktor();
    this.pozivGetTerminiDanas();
    this.pozivPrethodniTerminiDoktor();
  }

  getPodatkeOPacijentu(pacijentId : string){
    this.pozivPrethodniTerminiPacijent(pacijentId);
    this.getBolestiPacijenta(pacijentId);
    this.getNadolazeciTretmani(pacijentId);
  }
  getBolestiPacijenta(pacijentId:string){
     this.service.getBolestiZaPacijenta(pacijentId).subscribe(
      res=>{
        this.bolestiPacijenta=res;
      },
      err=>{
        console.log(err);
      }
    );
  }
  pozivPrethodniTerminiPacijent(pacijentId : string){
    this.service.getPrethodniTerminiPacijent(pacijentId).subscribe(
      res=>{
        this.prethodniTerminiPacijent = res;
      },
      err=>{
        console.log(err);
      }
    );
  }
  getNadolazeciTretmani(pacijentId : string){
    this.service.getNadolazeciTretmani(pacijentId).subscribe(
      res=>{
        this.nadolazeciTretmani = res;
      },
      err=>{
        console.log(err);
      }
    );
  }

  otvoriDodajOboljenje(pacijentId:string){
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
        this.service.addBolest(pacijentId, naziv, opis, icdKod).subscribe(
          res=>{
            Swal.fire({
              position: 'top-end',
              icon: 'success',
              title: 'Uspješno dodana bolest!',
              showConfirmButton: false,
              timer: 2500
            });
            console.log(pacijentId);
            this.getBolestiPacijenta(pacijentId);
          },
          err=>{
            console.log(err);
          }
        );
      }
    });
  }

  ukloniOboljenje(bolestId:any, pacijentId:any){
    this.service.deleteBolest(bolestId).subscribe(
      res=>{
        Swal.fire({
          position: 'top-end',
          icon: 'success',
          title: 'Uspješno uklonjeno oboljenje!',
          showConfirmButton: false,
          timer: 2500
        });
        this.getBolestiPacijenta(pacijentId);
      },
      err=>{
        console.log(err);
      }
    );
  }

  otvoriDodajTretman(pacijentId:string){
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
        this.service.addTretman(pacijentId, opis, napomena).subscribe(
          res=>{
            Swal.fire({
              position: 'top-end',
              icon: 'success',
              title: 'Uspješno dodan tretman!',
              showConfirmButton: false,
              timer: 2500
            });
            this.getNadolazeciTretmani(pacijentId);
          },
          err=>{
            console.log(err);
          }
        );
      }
    });
  }

  ukloniTretman(tretmanId:any, pacijentId:any){
    this.service.deleteTretman(tretmanId).subscribe(
      res=>{
        Swal.fire({
          position: 'top-end',
          icon: 'success',
          title: 'Uspješno uklonjeno oboljenje!',
          showConfirmButton: false,
          timer: 2500
        });
        this.getNadolazeciTretmani(pacijentId);
      },
      err=>{
        console.log(err);
      }
    );
  }

  pozivPrethodniTerminiDoktor(){
    this.service.getPrethodniTerminiDoktor().subscribe(
      res=>{
        this.prethodniTerminiDoktor = res;
      },err=>{
        console.log(err);
      }
    )
  }

  pozivTerminiKojiCekajuNaOdobrenjeDoktor(){
    this.service.getTerminiKojiCekajuNaOdobrenjeDoktor().subscribe(
      res=>{
        this.terminiKojiCekajuNaOdobrenjeDoktor = res;
      },
      err=>{
        console.log(err);
      }
    )
  }

  pozivGetTerminiDanas(){
    this.service.getTerminiDanas().subscribe(
      res=>{
        this.terminiDanas = res;
      },
      err=>{
        console.log(err);
      }
    )
  }

  visePodatakaOPacijentu(pacijentId : string){
    Swal.fire({
      title: 'Prelazak na stranicu o pacijentu!',
      text: "Nakon ovoga ćete morati ponovo pokrenuti pregled!",
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

  pozivOdobriPregled(ind : number){
    Swal.fire({
      title: 'Dodajte odgovor pacijentu ukoliko želite',
      input: 'text',
      inputAttributes: {
        autocapitalize: 'off'
      },
      showCancelButton: true,
      cancelButtonText: "Odustani",
      confirmButtonText: 'Potvrdi',
      confirmButtonColor: "green",
      showLoaderOnConfirm: true,
      preConfirm: (inputValue) => {
        let pr = {
          id : this.terminiKojiCekajuNaOdobrenjeDoktor[ind].id,
          odobreno : true,
          odgovor : inputValue
        }
        return this.service.odobriPregled(pr).subscribe(
          res=>{
            Swal.fire({
              position: 'top-end',
              icon: 'success',
              title: 'Uspješno odobren termin!',
              showConfirmButton: false,
              timer: 2500
            });
            this.pozivTerminiKojiCekajuNaOdobrenjeDoktor();
            this.pozivGetTerminiDanas();
          }
        )
      },
      allowOutsideClick: false
    });
  }

  pozivOdbijPregled(ind : number){
    Swal.fire({
      title: 'Da li ste sigurni da zelite odbiti zahtjev?',
      showCancelButton: true,
      cancelButtonText: "Odustani",
      confirmButtonText: 'Potvrdi',
      confirmButtonColor: "red",
      cancelButtonColor: "grey",
      showLoaderOnConfirm: true,
      preConfirm: () => {
        let pregledId = this.terminiKojiCekajuNaOdobrenjeDoktor[ind].id;
        return this.service.odbijPregled(pregledId).subscribe(
          res=>{
            Swal.fire({
              position: 'top-end',
              icon: 'warning',
              title: 'Uspješno odbijen zahtjev za termin!',
              showConfirmButton: false,
              timer: 2500
            });
            this.pozivTerminiKojiCekajuNaOdobrenjeDoktor();
            this.pozivGetTerminiDanas();
          }
        )
      },
      allowOutsideClick: false
    });
  }

  infoPacijent(ime : string, prezime : string, jmbg : string, pacijentId : string){
    let that = this;
    Swal.fire({
      title: "Podaci o pacijentu",
      html: "Ime: " + ime + "<br><br>Prezime: " + prezime + "<br><br>JMBG: " + jmbg,
      imageUrl: '/assets/dist/img/userAvatar.png',
      imageWidth: 150,
      imageHeight: 150,
      imageAlt: 'Custom image',
      showCancelButton: true,
      cancelButtonText: "Nazad",
      confirmButtonText: 'Više informacija o pacijentu',
      confirmButtonColor: "blue",
      preConfirm(){
        that.router.navigate(['pacijent'], {queryParams: {pacijentId : pacijentId}});
      }
    })
  }

  pozivZavrsiPregled(pregledId : any){
    if (this.dijagnoza==""||this.terapija==""){
      Swal.fire('Upozorenje','Polja dijagnoza i terapija moraju biti popunjena.', 'warning');
      return;
    }
    this.service.zavrsiPregled(pregledId, this.dijagnoza, this.terapija).subscribe(
      res=>{
        Swal.fire({
          position: 'top-end',
          icon: 'success',
          title: 'Uspješno zavrsen pregled!',
          showConfirmButton: false,
          timer: 2500
        });
        window.location.reload();
      },
      err=>{
        console.log(err);
      }
    );
  }
}
