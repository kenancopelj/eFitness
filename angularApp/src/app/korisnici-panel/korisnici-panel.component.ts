import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-konfig";
import { NotificationService } from '../notification.service';

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-korisnici-panel',
  templateUrl: './korisnici-panel.component.html',
  styleUrls: ['./korisnici-panel.component.css']
})
export class KorisniciPanelComponent implements OnInit{
  korisniciPodaci: any;
  odabraniKorisnik: any = null;


  constructor(private httpKlijent : HttpClient, private router : Router, private notificationService : NotificationService) {
  }

  ngOnInit(): void {
    this.getPodaci();
  }

  getPodaci() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Korisnik/GetAll",MojConfig.http_opcije()).subscribe((x=>{
      this.korisniciPodaci=x;
    }))
  }

  SpasiPromjene() {
  this.httpKlijent.put(MojConfig.adresa_servera+"/Korisnik/UpdateKaoAdmin/"+this.odabraniKorisnik.id,this.odabraniKorisnik,MojConfig.http_opcije()).subscribe((x=>{
    this.odabraniKorisnik = null;
    this.notificationService.showSuccess("Uspješno ažuriran korisnik",'Uspjeh');
  }),
  (err)=>this.notificationService.showError(err.error,'Greška'))
  }

  Obrisi(x:any){
    let id = x.id;
    console.log(id);
    this.httpKlijent.delete(MojConfig.adresa_servera+"/Korisnik/Remove/"+id,MojConfig.http_opcije()).subscribe((x=>{
      porukaSuccess("Uspješno izbrisan korisnik");
      this.getPodaci();
    }),
    (err)=>this.notificationService.showError(err.error,'Greška')
    )
  }
}
