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
import { GET_ALL_ON_PAGED_ENDPOINTS } from '../_helpers/config';

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

  narudzbaId;
  stavke: any[] = [];

  itemsPerPage = 12;
  currentPage = 1;
  totalItems = 0;

  logiran:any;


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

  ngOnInit(): void {
    this.fetchKategorijeSuplemenata();
    this.fetchSuplementi();
    this.items = [];
    this.logiran = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalog.isAdmin;


    this.NapraviNarudzbu();

  }

  AddItemToCart(item: any):void {

    if (!AutentifikacijaHelper.getLoginInfo().isLogiran)
      {
        this.notificationService.showError("Niste logirani","Greška");
        return;
      }

    const nova = {suplement_id : item.id , kolicina: 1}
    for(let i = 0; i < this.stavke.length; i++){
      if(nova.suplement_id == this.stavke[i].suplement.id && this.stavke[i].narudzba_id == this.narudzbaId){
        this.KorpaService.UpdateKolicina(this.stavke[i].id).subscribe((x:any)=>{
          this.notificationService.showSuccess('Suplement uspješno dodan','Success')
          this.GetStavkeUKorpi();
        },(err)=>this.notificationService.showError(err.error,'Greška'));

        return;
      }
    }
    this.KorpaService.AddStavka(nova,this.narudzbaId).subscribe((x:any)=>{
      this.notificationService.showSuccess('Suplement uspješno dodan','Success')
      this.GetStavkeUKorpi();
    },(err)=>this.notificationService.showError(err.error,'Greška'));

  }

  GetStavkeUKorpi() {
    this.KorpaService.GetStavkeByNarudzbaId(this.narudzbaId).subscribe((x:any)=>{
      this.stavke = x;
    })
  }

  prebaciNaKorpu() {

    if (!AutentifikacijaHelper.getLoginInfo().isLogiran)
      {
        this.notificationService.showError("Niste logirani","Greška");
        return;
      }

    console.log(this.narudzbaId)
    this.router.navigate(["/korpa",this.narudzbaId])
  }



  NapraviNarudzbu() {
    var kId = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalog.id.toString();
    this.KorpaService.AddNarudzba(kId).subscribe((x=>{
      this.narudzbaId = x;
      console.log(this.narudzbaId);
      this.GetStavkeUKorpi();

    }),
    (err)=>this.notificationService.showError(err.error,'Greška'))

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

  fetchSuplementi(body=null) {
    this.suplementiService.GetAll(!body ? {
      ...GET_ALL_ON_PAGED_ENDPOINTS,
      itemsPerPage: this.itemsPerPage,
      currentPage: this.currentPage
    } : {
      ...body,
      itemsPerPage: this.itemsPerPage,
      currentPage: this.currentPage
    }).subscribe((x:any)=>{
      this.suplementi=x.data;
      this.totalItems = x.pagedResult.totalItems;
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

  onPageChange(event) {
    this.currentPage = event;

     this.fetchSuplementi();
  }
}
