import {Component, OnInit} from '@angular/core';
import {LoginInformacije} from "../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-konfig";

@Component({
  selector: 'app-grupni-trening',
  templateUrl: './grupni-trening.component.html',
  styleUrls: ['./grupni-trening.component.css']
})
export class GrupniTreningComponent implements OnInit{
  kategorijeTreninga: any=[];
  noviTrening:any;
  grupniTreninzi: any=[];

  constructor(private httpKlijent: HttpClient, private router : Router) {
  }

  ngOnInit(): void {
    this.fetchKategorijeTreninga();
    this.fetchGrupneTreninge();
  }

  loginInfo():LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
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
