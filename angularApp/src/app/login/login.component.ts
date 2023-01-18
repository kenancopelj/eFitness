import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import {LoginInformacije} from "../_helpers/login-informacije";
import {MojConfig} from "../moj-konfig";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements  OnInit{

  txtLozinka: any;
  txtKorisnickoIme: any;
  suplementi: any=[];

  constructor(private httpKlijent: HttpClient, private router: Router) {
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
          alert("loginran");
        }
        else
        {
          AutentifikacijaHelper.setLoginInfo(null)

        }

      },
        (err)=>alert(err.error)
      );

  }

  fetchSuplemente() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Suplement/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{
      this.suplementi=x;
    },(err) => alert(err.error));
  }
}
