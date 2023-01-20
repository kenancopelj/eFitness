import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-konfig";
import {LoginInformacije} from "../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";

@Component({
  selector: 'app-clanarine',
  templateUrl: './clanarine.component.html',
  styleUrls: ['./clanarine.component.css']
})
export class ClanarineComponent implements OnInit{
  vrsteClanarina: any = [];
  novaClanarina: any=[];

  constructor(private router : Router, private httpKlijent : HttpClient) {
  }

  redirekcijaNaSuplemente() {
    this.router.navigateByUrl("/shop")
  }

  ngOnInit(): void {
    this.fetchVrsteClanarina();
  }

  loginInfo():LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }

  fetchVrsteClanarina() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/VrstaClanarine/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{
      this.vrsteClanarina = x;
    },(err)=>alert(err.error));
  }

  napraviNovu() {
    this.novaClanarina={
      prikazi:true,
      naziv:"",
      cijena:0
    }
  }
}
