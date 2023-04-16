import {Component, OnInit} from '@angular/core';
import {LoginInformacije} from "../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-konfig";
import { NotificationService } from '../notification.service';
import { GrupniTreningService } from './grupni-trening.service';

declare function porukaSuccess(a:string):any;
declare function porukaError(a:string):any;

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
  
  constructor(
    private httpKlijent: HttpClient,
    private router : Router,
    private notificationService : NotificationService,
    private grupniTreningService : GrupniTreningService
    ){}
  
  ngOnInit(): void {
    this.fetchKategorijeTreninga();
    this.fetchGrupneTreninge();
    this.korisnikId = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId;
    console.log(this.korisnikId)
  }
  
  loginInfo():LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }

  Prijava(trening_id : any) {

    const body = {
      korisnik_id : this.korisnikId,
      grupni_trening_id :  trening_id,
      datumPrijave : new Date()
    }

    this.grupniTreningService.PrijavaNaTrening(body).subscribe((x:any)=>{
      this.notificationService.showSuccess('Uspješna prijava','Success')
   },(err)=>this.notificationService.showError(`${err.error}`,'Greška'));
  }


  NapraviNoviTrening() {
    this.noviTrening={
      id:0,
      kategorija_id:1,
      vrijeme_odrzavanja:new Date()
    }
  }

  fetchKategorijeTreninga() {
    this.grupniTreningService.getKategorijeTreninga().subscribe((x:any)=>{
        this.kategorijeTreninga=x;
    },(err)=>this.notificationService.showError(`${err.error}`,'Greška'));
  }

  getSlikaById(x: number  ) {
    return this.grupniTreningService.getSlikaTreninga(x);
  }

  fetchGrupneTreninge() {
   this.grupniTreningService.GetAll().subscribe((x:any)=>{
      this.grupniTreninzi=x;
    },(err)=>this.notificationService.showError(`${err.error}`,'Greška'));
  }
}
