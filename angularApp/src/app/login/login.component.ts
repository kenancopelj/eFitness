import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import {LoginInformacije} from "../_helpers/login-informacije";
import {MojConfig} from "../moj-konfig";
import { NotificationService } from '../notification.service';
import { AuthService } from '../auth.service';

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
  openModal: any = false;
token: any;

  constructor(
  private httpKlijent: HttpClient, 
  private router: Router, 
  private notificationService : NotificationService,
  private authService : AuthService
  ) {
  }
  ngOnInit(): void {
  }

  aktivacija() {
    this.authService.aktivacija(this.token).subscribe((x:LoginInformacije)=>{
      if (x.isLogiran) {
        AutentifikacijaHelper.setLoginInfo(x)
        this.router.navigateByUrl("/home");
        this.notificationService.showSuccess("Uspješan login",'Success');
      }
      else
      {
        AutentifikacijaHelper.setLoginInfo(null)

      }
    },
    (err)=>this.notificationService.showError(err.error,'Error')
  );
  }

  btnLogin() {
    let saljemo = {
      korisnickoIme:this.txtKorisnickoIme,
      lozinka: this.txtLozinka
    };
    this.authService.logIn(saljemo)
      .subscribe((x:LoginInformacije) =>{

        this.openModal = true;

        this.notificationService.showInfo("Autentifikacijski token je poslan na Vaš mail!","Info");

        if (x.isLogiran) {
          console.log("Proso")
          AutentifikacijaHelper.setLoginInfo(x)
          this.router.navigateByUrl("/home");
          this.notificationService.showSuccess("Uspješan login",'Success');
        }
        else
        {
          console.log("Nije proso")
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
