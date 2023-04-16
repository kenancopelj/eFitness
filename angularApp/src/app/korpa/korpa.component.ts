import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NotificationService } from '../notification.service';
import { MojConfig } from '../moj-konfig';
import { KorpaServiceService } from '../korpa-service.service';

@Component({
  selector: 'app-korpa',
  templateUrl: './korpa.component.html',
  styleUrls: ['./korpa.component.css']
})
export class KorpaComponent implements OnInit {

  Suplementi : any[] = [];
  cartTotal : any = 0;

  ngOnInit(): void {
    this.izracunajTotal();
  }
  izracunajTotal() {
    let suma = 0;
    for(let i =0; i<this.Suplementi.length;i++){
      suma+= this.Suplementi[i].Price;
    }
    this.cartTotal = suma;
  }

  constructor(
  private httpKlijent:HttpClient, 
  private notificationService:NotificationService, 
  private KorpaService : KorpaServiceService)
  {
    this.Suplementi = KorpaService.getItems();
  }

  createOrder() {
    this.KorpaService.createOrder(this.Suplementi)
      .subscribe(response => {
        console.log('Order created successfully!');
        this.notificationService.showSuccess("Uspjesno izvrsena narudzba","Success");
        this.KorpaService.clearCart();
      });
  }

}
