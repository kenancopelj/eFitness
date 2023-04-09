import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NotificationService } from '../notification.service';
import { MojConfig } from '../moj-konfig';

@Component({
  selector: 'app-korpa',
  templateUrl: './korpa.component.html',
  styleUrls: ['./korpa.component.css']
})
export class KorpaComponent implements OnInit {

  storedItems : any;
  cartTotal : any;




  ngOnInit(): void {
    this.storedItems = JSON.parse(localStorage.getItem('items'));
    this.cartTotal = JSON.parse(localStorage.getItem('cartTotal'));

  }

  constructor(private httpKlijent:HttpClient, private notificationService:NotificationService){

  }


  createOrder() {
    const body =  { items: this.storedItems, total: this.cartTotal }
    // Make a POST request to the backend to create the order
    console.log("create ordre")
    this.httpKlijent.post(MojConfig.adresa_servera+"/Narudzba/CreateOrder", body ,MojConfig.http_opcije())
      .subscribe(response => {
        console.log('Order created successfully!');
        this.notificationService.showSuccess("Uspjesno izvrsena narudzba","Success");
        // Clear the cart
        this.storedItems = [];
        this.cartTotal = 0;
      });
  }

}
