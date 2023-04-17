import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MojConfig } from '../moj-konfig';
import { SuplementGetAllVm } from './suplement-get-all-vm';

@Injectable({
  providedIn: 'root'
})
export class SuplementiService {

  constructor(private http : HttpClient) { }

  GetKategorije(){
    return this.http.get(MojConfig.adresa_servera+"/KategorijaSuplementa/GetAll",MojConfig.http_opcije());
  }

  AddSuplement(body:any){
    return this.http.post<SuplementGetAllVm>(MojConfig.adresa_servera+"/Suplement/Add",body,MojConfig.http_opcije())
  }

  GetAllOld(){
    return this.http.get(MojConfig.adresa_servera+"/Suplement/GetAllOld",MojConfig.http_opcije());
  }

  GetAll(body){
    return this.http.post(MojConfig.adresa_servera+"/Suplement/GetAll",body,MojConfig.http_opcije());
  }

  Delete(id:any){
    return this.http.delete(MojConfig.adresa_servera+"/Suplement/Remove/"+id,MojConfig.http_opcije());
  }

  GetLastThree(){
    return this.http.get(MojConfig.adresa_servera+"/Suplement/GetLastThree",MojConfig.http_opcije());
  }

}
