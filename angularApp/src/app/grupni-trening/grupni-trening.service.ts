import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MojConfig } from '../moj-konfig';

@Injectable({
  providedIn: 'root'
})
export class GrupniTreningService {

  constructor(private http : HttpClient) { }

  PrijavaNaTrening(body:any){
    return this.http.post(MojConfig.adresa_servera+"/PrijavaGrupnihTreninga/Add",body,MojConfig.http_opcije());
  }

  getKategorijeTreninga()
  {
    return this.http.get(`${MojConfig.adresa_servera}/KategorijaTreninga/GetAll`,MojConfig.http_opcije());
  }

  getSlikaTreninga(id: number){
    return `${MojConfig.adresa_servera}/GrupniTrening/GetSlikaGrupnogTreninga/${id}`;
  }

  GetAll()
  {
    return this.http.get(MojConfig.adresa_servera+"/GrupniTrening/GetAll",MojConfig.http_opcije())
  }

}
