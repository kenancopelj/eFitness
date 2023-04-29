import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NotificationService } from '../notification.service';
import { MojConfig } from '../moj-konfig';
import { KorpaServiceService } from '../korpa-service.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-korpa',
  templateUrl: './korpa.component.html',
  styleUrls: ['./korpa.component.css']
})
export class KorpaComponent implements OnInit {

  Suplementi : any[] = [];
  cartTotal : any = 0;
  korpa : any[] = [];
  narudzbaID;


  constructor(
  private httpKlijent:HttpClient,
  private route:ActivatedRoute,
  private notificationService:NotificationService,
  private KorpaService : KorpaServiceService,
  private Router: Router)
  {

  }

  ngOnInit(): void {
    this.narudzbaID = this.route.snapshot.paramMap.get('id');
    this.GetStavkeUKorpi();
  }


  GetStavkeUKorpi() {
    this.KorpaService.GetStavkeByNarudzbaId(this.narudzbaID).subscribe((x:any)=>{
      this.korpa = x;
      this.izracunajTotal();
    })
  }


  izracunajTotal() {
    let suma = 0;
    for(let i =0; i<this.korpa.length;i++){
      suma+= this.korpa[i].suplement.cijena * this.korpa[i].kolicina;
    }
    this.cartTotal = suma;
  }

  UkloniIzKorpe(item){
    this.KorpaService.DeleteStavkaFromNarudzba(item.id).subscribe((x:any)=>{
      this.notificationService.showSuccess("Uspjesno izbrisana stavka","Success");
      this.GetStavkeUKorpi();
    },(err)=>this.notificationService.showError(err.error,'Greška'))
  }


  createOrder() {
    this.KorpaService.Kupljeno(this.narudzbaID).subscribe((x:any)=>{
      this.notificationService.showSuccess("Uspjesno kupljeno","Success");
      this.GetStavkeUKorpi();
      setTimeout(()=>{this.Router.navigateByUrl("/shop")},500);
    },(err)=>this.notificationService.showError(err.error,'Greška'))
  }

}
