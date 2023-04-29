import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-konfig";
import { NotificationService } from '../notification.service';
import { KorisniciService } from './korisnici.service';

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-korisnici-panel',
  templateUrl: './korisnici-panel.component.html',
  styleUrls: ['./korisnici-panel.component.css']
})
export class KorisniciPanelComponent implements OnInit{
  korisniciPodaci: any =[];
  odabraniKorisnik: any = null;


  constructor(
  private httpKlijent : HttpClient,
  private router : Router, 
  private notificationService : NotificationService,
  private korisniciService : KorisniciService
  ) {}

  ngOnInit(): void {
    this.getPodaci();
  }

  getPodaci() {
    this.korisniciService.GetAll().subscribe((x=>{
      this.korisniciPodaci=x;
    }))
  }

  isAdmin(korisnik){
    if(korisnik.is_admin)
      return '../../assets/admin.png';
    return '../../assets/user.png'
  }

  Administrator(id){
    this.korisniciService.MakeAdmin(id).subscribe((x:any)=>{
      this.getPodaci();
      this.notificationService.showSuccess("Uspješno update-ovan korisnik!","Success");
    },(err)=>this.notificationService.showError(err.error,'Greška'));
  }

  SpasiPromjene() {
  this.korisniciService.Save(this.odabraniKorisnik.id,this.odabraniKorisnik).subscribe((x=>{
    this.odabraniKorisnik = null;
    this.notificationService.showSuccess("Uspješno ažuriran korisnik",'Uspjeh');
  }),
  (err)=>this.notificationService.showError(err.error,'Greška'))
  }

  Obrisi(x:any){
    this.korisniciService.Delete(x).subscribe((x=>{
      this.notificationService.showSuccess("Uspješno izbrisan korisnik","Success");
      this.getPodaci();
    }),
    (err)=>this.notificationService.showError(err.error,'Greška')
    )
  }
}
