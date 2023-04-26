import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { MojConfig } from "../moj-konfig";
import { LoginInformacije } from "../_helpers/login-informacije";
import { AutentifikacijaHelper } from "../_helpers/autentifikacija-helper";
import { NotificationService } from '../notification.service';
import { KorisniciService } from '../korisnici-panel/korisnici.service';
import { ClanarineService } from '../clanarine/clanarine.service';
import { TreningService } from '../novi-trening/trening.service';

declare function porukaSuccess(a: string): any;
declare function porukaError(a: string): any;

@Component({
  selector: 'app-postavke-profila',
  templateUrl: './postavke-profila.component.html',
  styleUrls: ['./postavke-profila.component.css']
})
export class PostavkeProfilaComponent implements OnInit {
  trenutniKorisnik: any = [];
  odabraniKorisnik: any;
  clanarineKorisnika: any =[];
  potvrdjenaLozinka: any;
  novaSlika:any;
  prijaveKorisnika:any =[];

  constructor(
    private httpKlijent: HttpClient,
    private router: Router,
    private notificationService: NotificationService,
    private korisniciService: KorisniciService,
    private clanarineService: ClanarineService,
    private treningService : TreningService
  ) { }
  ngOnInit(): void {
    this.fetchTrenutnog();
    this.getClanarine();
    this.getMojePrijave();
  }

  getMojePrijave() {
    var id = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId;
    console.log("Ulazak")
    this.treningService.GetPrijavaByKorisnik(id).subscribe((x:any)=>{
      this.prijaveKorisnika = x;
      console.log(x)
    },(err)=>this.notificationService.showError(err.err,'Greška!'));
  }

  generisi_preview() {

    // @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if (file) {
      var reader = new FileReader();
      let this2 = this;
      reader.onload = function () {
        this2.novaSlika.slika_suplementa_base63 = reader.result.toString();

      }
      reader.readAsDataURL(file);
    }
  }

  getClanarine() {
    this.clanarineService.getByKorisnik().subscribe((x: any) => {
      this.clanarineKorisnika = x;
    }, (err) => this.notificationService.showInfo('Trenutno nemate aktivnih članarina', 'Info'))
  }

  getSlikaById(x: number) {
    return `${MojConfig.adresa_servera}/Korisnik/GetSlikaKorisnika/${x}`;
  }
  fetchTrenutnog() {
    this.korisniciService.GetTrenutni().subscribe((x: any) => {
      this.trenutniKorisnik = x;
    }, (err) => this.notificationService.showError(err.error, 'Greška'));
  }

  otkrijPassword() {
    let btn = document.getElementById("password");
    let tip = btn.getAttribute('type');
    tip == 'password' ? btn.setAttribute('type', 'text') : btn.setAttribute('type', 'password');
  }

  Odjava(prijavaId:any){
    this.treningService.OdjaviTrening(prijavaId).subscribe((x:any)=>{
      this.notificationService.showSuccess("Uspješno ste se odjavili sa treninga","Success!");
      this.getMojePrijave();
    },(err)=>this.notificationService.showError("Došlo je do greške!",'Greška'))
  }

  calculateImage(item): string {
    return item.aktivna == true ? "../../assets/true.png" : "../../assets/false.png";
  }
  Spasi() {
    if (this.odabraniKorisnik.lozinka == this.potvrdjenaLozinka) {
      this.korisniciService.Save(this.odabraniKorisnik.id, this.odabraniKorisnik).subscribe((x: any) => {
        this.notificationService.showSuccess('Uspješno pohranjeno!', 'Success')
        this.odabraniKorisnik = null;
      })
    }
    else
      this.notificationService.showError('Lozinke se ne podudaraju', 'Greška');
  }

}
