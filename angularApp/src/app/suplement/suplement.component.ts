import {Component, Input, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
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
  spasiPromjene() {
    this.httpKlijent.post(`${MojConfig.adresa_servera}/Suplement/Add`, this.noviSuplement, MojConfig.http_opcije()).subscribe(x=>{
      this.noviSuplement=null;
    });
  }

  get_slika_base64_FS(s: SuplementGetAllVm) {
    return "data:image/png;base64,"+ s.slika_suplement_base64;
  }

  get_slika_novi_request_FS(s: SuplementGetAllVm) {
    return `${MojConfig.adresa_servera}/Suplement/GetSlikaSuplement/${s.id}`;
  }

  generisi_preview() {
    // @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if (file) {
      var reader = new FileReader();
      let this2=this;
      reader.onload = function () {
        this2.noviSuplement.slika_korisnika_nova_base64 = reader.result.toString();
      }

      reader.readAsDataURL(file);
    }
  }
}
