import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {LoginInformacije} from "../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-konfig";
import {SuplementGetAllVm} from "../suplement/suplement-get-all-vm";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit{
  kategorijeSuplemenata: any = [];
  suplementi: any;
  odabraniSuplement: SuplementGetAllVm;
  kategorijaID: any=0;


  constructor(private router : Router, private httpKlijent:HttpClient) {
  }

  prebaciNaKorpu() {
   this.router.navigateByUrl("/korpa")
  }

  ngOnInit(): void {
    this.fetchKategorijeSuplemenata();
    this.fetchSuplementi();
  }

  getSuplementiPodaci(){
    if(this.kategorijaID!=0)
      return this.suplementi.filter(x=>x.kategorija_id==this.kategorijaID);
    return this.suplementi;
  }

  fetchKategorijeSuplemenata() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/KategorijaSuplementa/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{
      this.kategorijeSuplemenata=x;
    },(err)=>alert(err.error));
  }

  fetchSuplementi() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Suplement/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{
      this.suplementi=x;
    },(err)=>alert(err.error));
  }

  noviSuplementi(){
    this.odabraniSuplement={
      id:0,
      naziv:"",
      kategorija_id:1,
      opis:"",
      cijena:0,
      rokTrajanja:new Date(),
      slika_suplementa_base63:"",

    }
  }

  getSlikaById(x: number  ) {
    return `${MojConfig.adresa_servera}/Suplement/GetSlikaSuplementa/${x}`;
  }

  obrisiSuplementById(id:number) {
    this.httpKlijent.delete(MojConfig.adresa_servera+"/Suplement/Remove/"+id,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.fetchSuplementi();
    },(err)=>alert(err.error));
  }

  urediSuplementById(id) {

  }
}
