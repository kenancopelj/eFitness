import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient,HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-konfig";
import {SuplementGetAllVm} from "./suplement-get-all-vm";
import { NotificationService } from '../notification.service';
import { SuplementiService } from './suplementi.service';

@Component({
  selector: 'app-suplement',
  templateUrl: './suplement.component.html',
  styleUrls: ['./suplement.component.css']
})
export class SuplementComponent implements OnInit {
  @Input()noviSuplement:any;
  kategorije: any=[];
  @Output() ucitaj = new EventEmitter<void>();
  constructor(
  private router : Router,
  private httpKlijent:HttpClient,
  private notificationService : NotificationService,
  private suplementiService : SuplementiService
  ){}

  ngOnInit(): void {
    this.getKategorijeSuplementa();
  }

  getKategorijeSuplementa():void{
    this.suplementiService.GetKategorije().subscribe((x:any)=>{
      this.kategorije=x;
    });
  }

  generisi_preview() {

    // @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if (file) {
      var reader = new FileReader();
      let this2=this;
      reader.onload = function () {
        this2.noviSuplement.slika_suplementa_base63 = reader.result.toString();

      }
      reader.readAsDataURL(file);
    }
  }


  dodajNovu() {
    console.log(this.noviSuplement);
    this.suplementiService.AddSuplement(this.noviSuplement).subscribe((x:any)=>{
      this.notificationService.showSuccess('Suplement uspješno dodan','Success')
      this.noviSuplement=null;
      this.ucitaj.emit();
    },(err)=>this.notificationService.showError(err.error,'Greška'));
  }



}
