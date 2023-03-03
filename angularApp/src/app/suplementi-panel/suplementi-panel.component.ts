import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-konfig";

@Component({
  selector: 'app-suplementi-panel',
  templateUrl: './suplementi-panel.component.html',
  styleUrls: ['./suplementi-panel.component.css']
})
export class SuplementiPanelComponent implements  OnInit{
  suplementiPodaci: any;

  constructor(private httpKlijent : HttpClient, private router : Router) {
  }

  ngOnInit(): void {
    this.getPodaci();
  }

   getPodaci() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Suplement/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{
      this.suplementiPodaci=x;
    })
  }
}
