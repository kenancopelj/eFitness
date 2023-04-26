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

  AddNarudzba(korisnikid : any){
    return this.http.post(MojConfig.adresa_servera+"/Narudzba/AddNarudzba/"+korisnikid, MojConfig.http_opcije())
  }

  AddStavka(body:any , narID : any){
    return this.http.post(MojConfig.adresa_servera+"/StavkeNarudzbe/Add/"+narID,body,MojConfig.http_opcije())
  }

  GetStavkeByNarudzbaId(narID : any){
    return this.http.get(MojConfig.adresa_servera+"/StavkeNarudzbe/GetStavkeNarudzbeByNarudzbaId/"+narID, MojConfig.http_opcije())
  }

  DeleteStavkaFromNarudzba(itemId : any){
    return this.http.delete(MojConfig.adresa_servera+"/StavkeNarudzbe/DeleteStavkaFromNarudzba/"+itemId, MojConfig.http_opcije())
  }

  UpdateKolicina(itemId : any){
    return this.http.put(MojConfig.adresa_servera+"/StavkeNarudzbe/UpdateKolicina/"+itemId,MojConfig.http_opcije())
  }

  Kupljeno(itemId : any){
    return this.http.put(MojConfig.adresa_servera+"/Narudzba/Kupljeno/"+itemId,MojConfig.http_opcije())
  }

}
