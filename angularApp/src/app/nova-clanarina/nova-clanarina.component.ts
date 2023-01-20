import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-konfig";

@Component({
  selector: 'app-nova-clanarina',
  templateUrl: './nova-clanarina.component.html',
  styleUrls: ['./nova-clanarina.component.css']
})
export class NovaClanarinaComponent implements OnInit{
  @Input() novaClanarina:any;
  @Output() ucitaj = new EventEmitter<void>();

  constructor(private httpKlijent : HttpClient) {
  }

  ngOnInit(): void {
  }

  spasiPromjene() {
      this.httpKlijent.post(MojConfig.adresa_servera+"/VrstaClanarine/Add",this.novaClanarina,MojConfig.http_opcije()).subscribe((x:any)=>{
        this.novaClanarina.prikazi=false;
        this.ucitaj.emit();
      },(err)=>alert(err.error));
  }
}
