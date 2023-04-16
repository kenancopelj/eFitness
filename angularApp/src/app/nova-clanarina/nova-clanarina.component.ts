import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-konfig";
import { NotificationService } from '../notification.service';
import { ClanarineService } from '../clanarine/clanarine.service';

@Component({
  selector: 'app-nova-clanarina',
  templateUrl: './nova-clanarina.component.html',
  styleUrls: ['./nova-clanarina.component.css']
})
export class NovaClanarinaComponent implements OnInit{
  @Input() novaClanarina:any;
  @Output() ucitaj = new EventEmitter<void>();

  constructor(
  private httpKlijent : HttpClient, 
  private notificationService : NotificationService,
  private clanarineService : ClanarineService
  ) {
  }

  ngOnInit(): void {
  }

  spasiPromjene() {
      this.clanarineService.Add(this.novaClanarina).subscribe((x:any)=>{
        this.notificationService.showSuccess('Uspješno spašeno','Success')
        this.novaClanarina.prikazi=false;
        this.ucitaj.emit();
      },(err)=>this.notificationService.showError(err.error,'Greška'));
  }
}
