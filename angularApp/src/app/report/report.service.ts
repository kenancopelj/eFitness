import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MojConfig } from '../moj-konfig';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  constructor(private http : HttpClient) { }

  GetAllRacuni(){
    return this.http.get(MojConfig.adresa_servera+"/Narudzba/GetIdsOfNarudzba",MojConfig.http_opcije());
  }



}
