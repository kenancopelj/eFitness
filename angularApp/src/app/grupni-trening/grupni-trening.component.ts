import {Component, OnInit} from '@angular/core';
import {LoginInformacije} from "../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-konfig";

declare function porukaSucces(a:string):any;
declare function porukeError(a:string):any;

@Component({
  selector: 'app-grupni-trening',
  templateUrl: './grupni-trening.component.html',
  styleUrls: ['./grupni-trening.component.css']
})
export class GrupniTreningComponent implements OnInit{
  kategorijeTreninga: any=[];
  noviTrening:any;
  grupniTreninzi: any=[];
  korisnikId : any;
  
  constructor(private httpKlijent: HttpClient, private router : Router) {
  }
  
  ngOnInit(): void {
    this.fetchKategorijeTreninga();
    this.fetchGrupneTreninge();
    this.korisnikId = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId
  }
  
  loginInfo():LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }

  Prijava(trening_id : any) {
    console.log(trening_id)
    const body = {
      korisnik_id : this.korisnikId,
      grupni_trening_id :  trening_id,
      datumPrijave : new Date()
    }
    this.httpKlijent.post(MojConfig.adresa_servera+"/PrijavaGrupnihTreninga/Add",body,MojConfig.http_opcije()).subscribe((x:any)=>{
      porukaSucces("Uspješna prijava na trening")
   },(err)=>alert(err.error));
  }


  NapraviNoviTrening() {
    this.noviTrening={
      id:0,
      kategorija_id:1,
      vrijeme_odrzavanja:new Date()
    }
  }

  fetchKategorijeTreninga() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/KategorijaTreninga/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{
        this.kategorijeTreninga=x;
    },(err)=>alert(err.error));
  }

  getSlikaById(x: number  ) {
    return `${MojConfig.adresa_servera}/GrupniTrening/GetSlikaGrupnogTreninga/${x}`;
  }

  fetchGrupneTreninge() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/GrupniTrening/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{
      this.grupniTreninzi=x;
    },(err)=>alert(err.error));
  }
}
