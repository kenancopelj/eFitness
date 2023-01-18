import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {LoginInformacije} from "../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-konfig";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit{
  kategorijeSuplemenata: any = [];

  constructor(private router : Router, private httpKlijent:HttpClient) {
  }

  prebaciNaKorpu() {
   this.router.navigateByUrl("/korpa")
  }
  loginInfo():LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }

  ngOnInit(): void {
    this.fetchKategorijeSuplemenata();
  }

  fetchKategorijeSuplemenata() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/KategorijaSuplementa/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{
      this.kategorijeSuplemenata=x;
    },(err)=>alert(err.error));
  }

}
