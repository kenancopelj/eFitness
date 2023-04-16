import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-konfig";
import { SuplementiService } from '../suplement/suplementi.service';

@Component({
  selector: 'app-suplementi-panel',
  templateUrl: './suplementi-panel.component.html',
  styleUrls: ['./suplementi-panel.component.css']
})
export class SuplementiPanelComponent implements  OnInit{
  suplementiPodaci: any;

  constructor(
  private httpKlijent : HttpClient, 
  private router : Router,
  private suplementiService : SuplementiService
  ){}

  ngOnInit(): void {
    this.getPodaci();
  }

   getPodaci() {
    this.suplementiService.GetAll().subscribe((x:any)=>{
      this.suplementiPodaci=x;
    })
  }
}
