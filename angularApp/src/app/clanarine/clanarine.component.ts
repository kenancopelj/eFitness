import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-konfig";
import {LoginInformacije} from "../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import { NotificationService } from '../notification.service';
import { ClanarineService } from './clanarine.service';

@Component({
  selector: 'app-clanarine',
  templateUrl: './clanarine.component.html',
  styleUrls: ['./clanarine.component.css']
})
export class ClanarineComponent implements OnInit{
  vrsteClanarina: any = [];
  novaClanarina: any=[];
  
  constructor(
    private router : Router,
    private httpKlijent : HttpClient,
    private notificationService : NotificationService,
    private clanarineService : ClanarineService
    ){}
  
  redirekcijaNaSuplemente() {
    this.router.navigateByUrl("/shop")
  }
  
  ngOnInit(): void {
    this.fetchVrsteClanarina();
  }
  
  loginInfo():LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }

  novoUclanjenje(idClanarine: number) {
    console.log(idClanarine)
    this.router.navigate(['/novo-uclanjenje',idClanarine])
  }

  fetchVrsteClanarina() {
    this.clanarineService.getVrsteClanarina().subscribe((x:any)=>{
      this.vrsteClanarina = x;
    },(err)=>this.notificationService.showError(`${err.error}`,'Greška'));
  }

  napraviNovu() {
    this.novaClanarina={
      prikazi:true,
      naziv:"",
      cijena:0
    }
  }
}
