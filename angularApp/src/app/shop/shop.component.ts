import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {LoginInformacije} from "../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-konfig";
import {SuplementGetAllVm} from "../suplement/suplement-get-all-vm";
import { NgxSpinnerService } from 'ngx-spinner';
import { NotificationService } from '../notification.service';
import { KorpaServiceService } from '../korpa-service.service';
import { SuplementiService } from '../suplement/suplementi.service';

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

  items: any[] = [];
  cartTotal: number = 0;

  constructor(
  private router : Router,
  private httpKlijent:HttpClient,
  private spinner : NgxSpinnerService,
  private notificationService : NotificationService,
  private KorpaService : KorpaServiceService,
  private suplementiService : SuplementiService
  ) {
    this.items = this.KorpaService.getItems();

  }

  AddItemToCart(item: any) {
    const nova = {Name : item.naziv, Price: item.cijena, Quantity: 1}
    this.KorpaService.addItem(nova);
  }

  prebaciNaKorpu() {
    this.router.navigateByUrl("/korpa")
  }

  ngOnInit(): void {
    this.fetchKategorijeSuplemenata();
    this.fetchSuplementi();
    this.KorpaService.clearCart();
    this.items = [];
  }

  getSuplementiPodaci(){
    if(this.kategorijaID!=0)
      return this.suplementi.filter(x=>x.kategorija_id==this.kategorijaID);
    return this.suplementi;
  }

  fetchKategorijeSuplemenata() {
    this.suplementiService.GetKategorije().subscribe((x:any)=>{
      this.kategorijeSuplemenata=x;
    },(err)=>this.notificationService.showError(err.error,'Greška'));
  }

  fetchSuplementi() {
    this.suplementiService.GetAll().subscribe((x:any)=>{
      this.suplementi=x;
    },(err)=>this.notificationService.showError(err.error,'Greška'));
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
    this.suplementiService.Delete(id).subscribe((x:any)=>{
      this.notificationService.showInfo('Suplement obrisan','Info')
      this.fetchSuplementi();
    },(err)=>this.notificationService.showError(err.error,'Greška'));
  }

  urediSuplementById(id) {

  }
}
