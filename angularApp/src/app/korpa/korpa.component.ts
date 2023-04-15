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
  cartTotal : any;




  ngOnInit(): void {
    this.Suplementi = JSON.parse(localStorage.getItem('items'));
    this.cartTotal = JSON.parse(localStorage.getItem('cartTotal'));

  }

  constructor(private httpKlijent:HttpClient, private notificationService:NotificationService, private KorpaService : KorpaServiceService){
    this.Suplementi = KorpaService.getItems();
  }



  createOrder() {

    // Make a POST request to the backend to create the order
    console.log("create ordre")
    this.httpKlijent.post(MojConfig.adresa_servera+"/Narudzba/CreateOrder", this.Suplementi, MojConfig.http_opcije())
      .subscribe(response => {
        console.log('Order created successfully!');
        this.notificationService.showSuccess("Uspjesno izvrsena narudzba","Success");
        // Clear the cart
        this.KorpaService.clearCart();
      });
  }

}
