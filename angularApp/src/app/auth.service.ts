import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginInformacije } from './_helpers/login-informacije';
import { MojConfig } from './moj-konfig';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http : HttpClient) { }

  logIn(body:any){
    return this.http.post<LoginInformacije>(`${MojConfig.adresa_servera}/Autentifikacija/Login/`,body);
  }

}
