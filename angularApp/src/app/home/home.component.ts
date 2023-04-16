import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import { SuplementiService } from '../suplement/suplementi.service';
import { NotificationService } from '../notification.service';
import { MojConfig } from '../moj-konfig';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  suplementi : any[] = [];

  constructor(
  private router : Router, 
  private httpKlijent:HttpClient, 
  private suplementService : SuplementiService,
  private notificationService : NotificationService
  ){}


  redirekcijaNaShop() {
    this.router.navigateByUrl("/clanarine");
  }

  ngOnInit(): void {
    this.getLastThreeSuplements();
  }
  getLastThreeSuplements() {
    this.suplementService.GetLastThree().subscribe((x:any)=>{
      this.suplementi = x;
      console.log(this.suplementi)
    },(err)=>this.notificationService.showError("Došlo je do greške!","Greška"))
  }

  getSlikaById(x: number  ) {
    return `${MojConfig.adresa_servera}/Suplement/GetSlikaSuplementa/${x}`;
  }

}
