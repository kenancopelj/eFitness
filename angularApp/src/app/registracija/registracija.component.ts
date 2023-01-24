import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import * as http from "http";
import {MojConfig} from "../moj-konfig";
import {KorisnikVM} from "./novi-korisnik-vm";
import {LoginInformacije} from "../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";


declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;
@Component({
  selector: 'app-registracija',
  templateUrl: './registracija.component.html',
  styleUrls: ['./registracija.component.css']
})
export class RegistracijaComponent implements OnInit{
  txtKorisnickoIme: any;
  txtLozinka: any;
  txtPonovljenaLozinka: any;
  noviKorisnik : KorisnikVM=new KorisnikVM();

  korisnici:any=[];
  constructor(private httpKlijent : HttpClient, private router : Router) {
  }
  ngOnInit(): void {
    this.fetchKorisnici();
  }

  btnRegistracija() {
      if(this.Validiraj())
      {
          this.httpKlijent.post<KorisnikVM>(MojConfig.adresa_servera+"/Korisnik/Add",this.noviKorisnik,MojConfig.http_opcije()).subscribe((x:any)=>{
            porukaSuccess("Uspješna registracija!");
            this.LogirajSe(this.noviKorisnik);
          },(err)=>alert(err.error));
      }
  }

  LogirajSe(noviKorisnik: KorisnikVM) {
    let saljemo = {
      korisnickoIme:noviKorisnik.korisnicko_ime,
      lozinka: noviKorisnik.lozinka
    };
    this.httpKlijent.post<LoginInformacije>(MojConfig.adresa_servera+ "/Autentifikacija/Login/", saljemo)
      .subscribe((x:LoginInformacije) =>{
          if (x.isLogiran) {
            AutentifikacijaHelper.setLoginInfo(x)
            this.router.navigateByUrl("/home");
            porukaSuccess("Uspješan login");
          }
          else
          {
            AutentifikacijaHelper.setLoginInfo(null)
          }

        },
        (err)=>porukaError(err.error)
      );
  }

  Validiraj() {
    return this.noviKorisnik.lozinka==this.txtPonovljenaLozinka && !this.NePostoji();
  }

  NePostoji() {
    for (let i=0; i< this.korisnici.length; i++)
      if (this.korisnici[i].korisnicko_ime == this.txtKorisnickoIme) {
        porukaError("Vec postoji ovo korisnicko ime");
        return true;
      }
    return false;
  }


  generisi_preview() {
    // @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if (file) {
      var reader = new FileReader();
      let this2=this;
      reader.onload = function () {
        this2.noviKorisnik.slika_korisnika_base63 = reader.result.toString();

      }
      reader.readAsDataURL(file);
    }
  }

  fetchKorisnici() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Korisnik/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{
      this.korisnici=x;
    },(err)=>alert(err.error));
  }

}
