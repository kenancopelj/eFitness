import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../moj-konfig";

@Component({
  selector: 'app-novi-trening',
  templateUrl: './novi-trening.component.html',
  styleUrls: ['./novi-trening.component.css']
})
export class NoviTreningComponent implements OnInit{
  @Input() napraviNovi :any;
  @Output() ucitajTreninge = new EventEmitter<void>();
  kategorijeTreninga: any;

  constructor(private httpKlijent:HttpClient, private router : Router) {
  }

  ngOnInit(): void {
    this.fetchKategorijeTreninga();
  }

  fetchKategorijeTreninga() {
    this.httpKlijent.get(MojConfig.adresa_servera+"/KategorijaTreninga/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{
      this.kategorijeTreninga=x;
    },(err)=>alert(err.error));
  }

  generisi_preview() {
// @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if (file) {
      var reader = new FileReader();
      let this2=this;
      reader.onload = function () {
        this2.napraviNovi.slika_suplementa_base63 = reader.result.toString();

      }
      reader.readAsDataURL(file);
    }
  }

  dodajNovi() {
    this.httpKlijent.post(MojConfig.adresa_servera+"/GrupniTrening/Add",this.napraviNovi,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.napraviNovi=null;
      this.ucitajTreninge.emit();
    },(err)=>alert(err.error));
  }
}
