import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-konfig";
import { SuplementiService } from '../suplement/suplementi.service';
import { NotificationService } from '../notification.service';
import { GET_ALL_ON_PAGED_ENDPOINTS } from '../_helpers/config';

@Component({
  selector: 'app-suplementi-panel',
  templateUrl: './suplementi-panel.component.html',
  styleUrls: ['./suplementi-panel.component.css']
})
export class SuplementiPanelComponent implements  OnInit{
  suplementiPodaci: any=[];

  itemsPerPage = 5;
  currentPage = 1;
  totalItems = 0;

  constructor(
  private httpKlijent : HttpClient,
  private router : Router,
  private suplementiService : SuplementiService,
  private notificationService : NotificationService
  ){}

  ngOnInit(): void {
    this.fetchSuplementi();
  }

  onPageChange(event) {
    this.currentPage = event;

     this.fetchSuplementi();
  }

  fetchSuplementi(body=null) {
    this.suplementiService.GetAll(!body ? {
      ...GET_ALL_ON_PAGED_ENDPOINTS,
      itemsPerPage: this.itemsPerPage,
      currentPage: this.currentPage
    } : {
      ...body,
      itemsPerPage: this.itemsPerPage,
      currentPage: this.currentPage
    }).subscribe((x:any)=>{
      this.suplementiPodaci=x.data;
      this.totalItems = x.pagedResult.totalItems;
    },(err)=>this.notificationService.showError(err.error,'Greška'));
  }

  getSlikaSuplementa(id:any){
      return `${MojConfig.adresa_servera}/Suplement/GetSlikaSuplementa/${id}`;
  }
}
