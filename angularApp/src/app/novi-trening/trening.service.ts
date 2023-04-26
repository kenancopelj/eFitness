import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MojConfig } from '../moj-konfig';

@Injectable({
  providedIn: 'root'
})
export class TreningService {

  constructor(private http : HttpClient) { }

  GetKategorijeTreninga(){
    return this.http.get(MojConfig.adresa_servera+"/KategorijaTreninga/GetAll",MojConfig.http_opcije());
  }

  Add(body:any){
    return this.http.post(MojConfig.adresa_servera+"/GrupniTrening/Add",body,MojConfig.http_opcije());
  }

  GetAll(){
    return this.http.get(MojConfig.adresa_servera+"/GrupniTrening/GetAll",MojConfig.http_opcije());
  }

  GetPrijavaByKorisnik(id:any){
    return this.http.get(`${MojConfig.adresa_servera}/PrijavaGrupnihTreninga/GetPrijaveByKorisnik/${id}`,MojConfig.http_opcije());
  }

  OdjaviTrening(id:any){
    return this.http.delete(`${MojConfig.adresa_servera}/PrijavaGrupnihTreninga/Remove/${id}`,MojConfig.http_opcije());
  }

  Remove(id:any){
    return this.http.delete(`${MojConfig.adresa_servera}/GrupniTrening/Remove/${id}`,MojConfig.http_opcije());
  }

}
