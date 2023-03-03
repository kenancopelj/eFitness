import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-konfig";
import {LoginInformacije} from "../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";

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

  constructor(private httpKlijent : HttpClient, private router : Router) {
  }
  ngOnInit(): void {
    this.fetchTrenutnog();
  }

  getSlikaById(x: number  ) {
    return `${MojConfig.adresa_servera}/Korisnik/GetSlikaKorisnika/${x}`;
  }
  fetchTrenutnog() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Korisnik/GetTrenutni",MojConfig.http_opcije()).subscribe((x:any)=>{
        this.trenutniKorisnik=x;
    },(err)=>porukaError(err.error()));
  }

  otkrijPassword() {
    let btn = document.getElementById("password");
    let tip = btn.getAttribute('type');
    tip == 'password' ? btn.setAttribute('type','text'):btn.setAttribute('type','password');
  }

}
