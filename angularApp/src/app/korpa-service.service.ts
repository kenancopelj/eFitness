import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MojConfig } from './moj-konfig';

@Injectable({
  providedIn: 'root'
})
export class KorpaServiceService {

  constructor(private http: HttpClient) { }

  items: any[] = [];

  addItem(item: any) {
    this.items.push(item);
  }

  removeItem(item: any) {
    const index = this.items.indexOf(item);
    if (index !== -1) {
      this.items.splice(index, 1);
    }
  }

  getItems() {
    return this.items;
  }

  clearCart() {
    this.items = [];
  }

  createOrder(items : any){
    return this.http.post(MojConfig.adresa_servera+"/Narudzba/CreateOrder/placeorder", items, MojConfig.http_opcije())
  }

}
