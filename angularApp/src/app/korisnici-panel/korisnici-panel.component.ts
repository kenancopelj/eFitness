import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-konfig";

@Component({
  selector: 'app-korisnici-panel',
  templateUrl: './korisnici-panel.component.html',
  styleUrls: ['./korisnici-panel.component.css']
})
export class KorisniciPanelComponent implements OnInit{
  korisniciPodaci: any;

  constructor(private httpKlijent : HttpClient, private router : Router) {
  }

  ngOnInit(): void {
    this.getPodaci();
  }

   getPodaci() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Korisnik/GetAll",MojConfig.http_opcije()).subscribe((x=>{
      this.korisniciPodaci=x;
    }))
  }
}
