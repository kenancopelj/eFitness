import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-konfig";
import {LoginInformacije} from "../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import { NotificationService } from '../notification.service';

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-postavke-profila',
  templateUrl: './postavke-profila.component.html',
  styleUrls: ['./postavke-profila.component.css']
})
export class PostavkeProfilaComponent implements OnInit{
  trenutniKorisnik: any=[];
  odabraniKorisnik: any;
  clanarineKorisnika : any;

  constructor(
  private httpKlijent : HttpClient,
  private router : Router,
  private notificationService : NotificationService
  ){}
  ngOnInit(): void {
    this.fetchTrenutnog();
    this.getClanarine();
  }

  getClanarine(){
    this.httpKlijent.get(`${MojConfig.adresa_servera}/GetByKorisnik`,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.clanarineKorisnika = x;
    },(err)=>this.notificationService.showInfo('Trenutno nemate aktivnih članarina','Info'))
  }

  getSlikaById(x: number  ) {
    return `${MojConfig.adresa_servera}/Korisnik/GetSlikaKorisnika/${x}`;
  }
  fetchTrenutnog() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Korisnik/GetTrenutni",MojConfig.http_opcije()).subscribe((x:any)=>{
        this.trenutniKorisnik=x;
    },(err)=>this.notificationService.showError(err.error,'Greška'));
  }

  otkrijPassword() {
    let btn = document.getElementById("password");
    let tip = btn.getAttribute('type');
    tip == 'password' ? btn.setAttribute('type','text'):btn.setAttribute('type','password');
  }

}
