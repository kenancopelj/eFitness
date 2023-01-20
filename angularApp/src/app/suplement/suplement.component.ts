import {Component, Input, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient,HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-konfig";
import {SuplementGetAllVm} from "./suplement-get-all-vm";

@Component({
  selector: 'app-suplement',
  templateUrl: './suplement.component.html',
  styleUrls: ['./suplement.component.css']
})
export class SuplementComponent implements OnInit {
  @Input()noviSuplement:any;
  kategorije: any=[];

  constructor(private router : Router, private httpKlijent:HttpClient) {
  }

  ngOnInit(): void {
    this.getKategorijeSuplementa();
  }

  getKategorijeSuplementa():void{
    this.httpKlijent.get(MojConfig.adresa_servera+"/KategorijaSuplementa/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{
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
        this2.noviSuplement.slika_suplement_base63 = reader.result.toString();

      }

      reader.readAsDataURL(file);
    }
  }

  dodajNovu() {

    console.log(this.noviSuplement.slika_suplement_base64);
    this.httpKlijent.post<SuplementGetAllVm>(MojConfig.adresa_servera+"/Suplement/Add",this.noviSuplement,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.noviSuplement=null;
    },(err)=>alert(err.error));
  }
}
