import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MojConfig } from '../moj-konfig';

@Injectable({
  providedIn: 'root'
})
export class ClanarineService {

  constructor(private http : HttpClient) { }

  getVrsteClanarina(){
    return this.http.get(`${MojConfig.adresa_servera}/VrstaClanarine/GetAll`,MojConfig.http_opcije());
  }

  Add(body:any){
    return this.http.post(MojConfig.adresa_servera+"/VrstaClanarine/Add",body,MojConfig.http_opcije());
  }

  GetVrstaById(id:any){
    return this.http.get(MojConfig.adresa_servera+`/VrstaClanarine/GetById/${id}`,MojConfig.http_opcije())
  }

  novaClanarina(body:any){
    return this.http.post(`${MojConfig.adresa_servera}/Clanarina/Add`,body,MojConfig.http_opcije())
  }

  getByKorisnik(){
    return this.http.get(`${MojConfig.adresa_servera}/Clanarina/GetByKorisnik`,MojConfig.http_opcije())
  }


}
