import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import {LoginInformacije} from "../_helpers/login-informacije";
import {MojConfig} from "../moj-konfig";
import { NotificationService } from '../notification.service';

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements  OnInit{

  txtLozinka: any;
  txtKorisnickoIme: any;
  suplementi: any=[];

  constructor(private httpKlijent: HttpClient, private router: Router, private notificationService : NotificationService) {
  }
  ngOnInit(): void {
    this.fetchSuplemente();
  }

  btnLogin() {
    let saljemo = {
      korisnickoIme:this.txtKorisnickoIme,
      lozinka: this.txtLozinka
    };
    this.httpKlijent.post<LoginInformacije>(MojConfig.adresa_servera+ "/Autentifikacija/Login/", saljemo)
      .subscribe((x:LoginInformacije) =>{
        if (x.isLogiran) {
          AutentifikacijaHelper.setLoginInfo(x)
          this.router.navigateByUrl("/home");
          this.notificationService.showSuccess("Uspješan login",'');
        }
        else
        {
          AutentifikacijaHelper.setLoginInfo(null)

        }

      },
        (err)=>this.notificationService.showError(err.error,'Error')
      );

  }

  fetchSuplemente() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Suplement/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{
      this.suplementi=x;
    },(err) => this.notificationService.showError(err.error,'Greška'));
  }
}
