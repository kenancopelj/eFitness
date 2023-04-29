import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MojConfig } from '../moj-konfig';
import { KorisnikVM } from '../registracija/novi-korisnik-vm';

@Injectable({
  providedIn: 'root'
})
export class KorisniciService {

  constructor(private http : HttpClient) { }

  MakeAdmin(id){
    return this.http.put(`${MojConfig.adresa_servera}/Korisnik/UpdateAdminRole/${id}`,MojConfig.http_opcije());
  }

  GetAll(){
    return this.http.get(MojConfig.adresa_servera+"/Korisnik/GetAll",MojConfig.http_opcije());
  }
    
  Save(id : any, odabraniKorisnik:any){
    return this.http.put(`${MojConfig.adresa_servera}/Korisnik/UpdateKaoAdmin/${id}`,odabraniKorisnik,MojConfig.http_opcije());
  }

  UpdateImage(id:any,body:any){
    return this.http.put(`${MojConfig.adresa_servera}/Korisnik/UpdateSlikaKorisnika/${id}`,body,MojConfig.http_opcije());
  }

  Delete(id:any){
    return this.http.delete(MojConfig.adresa_servera+"/Korisnik/Remove/"+id,MojConfig.http_opcije())
  }

  GetTrenutni(){
    return this.http.get(MojConfig.adresa_servera+"/Korisnik/GetTrenutni",MojConfig.http_opcije())
  }

  Add(body:any){
    return this.http.post<KorisnikVM>(MojConfig.adresa_servera+"/Korisnik/Add",body,MojConfig.http_opcije())
  }

}
