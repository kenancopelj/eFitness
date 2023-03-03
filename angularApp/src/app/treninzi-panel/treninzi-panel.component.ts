import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-konfig";

@Component({
  selector: 'app-treninzi-panel',
  templateUrl: './treninzi-panel.component.html',
  styleUrls: ['./treninzi-panel.component.css']
})
export class TreninziPanelComponent implements  OnInit{
  treninziPodaci: any;

  constructor(private httpKlijent : HttpClient, private rotuer : Router) {
  }
  ngOnInit(): void {
    this.getPodaci();
  }

   getPodaci() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/GrupniTrening/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{
      this.treninziPodaci=x;
    })
  }
}
