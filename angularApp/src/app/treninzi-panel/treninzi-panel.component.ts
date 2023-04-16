import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-konfig";
import { NotificationService } from '../notification.service';
import { TreningService } from '../novi-trening/trening.service';

@Component({
  selector: 'app-treninzi-panel',
  templateUrl: './treninzi-panel.component.html',
  styleUrls: ['./treninzi-panel.component.css']
})
export class TreninziPanelComponent implements  OnInit{
  treninziPodaci: any;

  constructor(
  private httpKlijent : HttpClient, 
  private rotuer : Router, 
  private notificationService : NotificationService,
  private treningService : TreningService
  ) {
  }
  ngOnInit(): void {
    this.getPodaci();
  }

   getPodaci() {
    this.treningService.GetAll().subscribe((x:any)=>{
      this.treninziPodaci=x;
    },(err)=>this.notificationService.showError(err.error,'Greška'))
  }
}
