import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { MojConfig } from "../moj-konfig";
import { NotificationService } from '../notification.service';
import { TreningService } from '../novi-trening/trening.service';
import { GrupniTreningService } from '../grupni-trening/grupni-trening.service';

@Component({
  selector: 'app-treninzi-panel',
  templateUrl: './treninzi-panel.component.html',
  styleUrls: ['./treninzi-panel.component.css']
})
export class TreninziPanelComponent implements OnInit {
  treninziPodaci: any = [];

  constructor(
    private httpKlijent: HttpClient,
    private rotuer: Router,
    private notificationService: NotificationService,
    private treningService: TreningService,
    private grupniTreningService: GrupniTreningService
  ) {
  }
  ngOnInit(): void {
    this.getPodaci();
  }

  getSlikaById(x: number) {
    return this.grupniTreningService.getSlikaTreninga(x);
  }

  getPodaci() {
    this.treningService.GetAll().subscribe((x: any) => {
      this.treninziPodaci = x;
    }, (err) => this.notificationService.showError(err.error, 'Greška'))
  }

  Obrisi(id: any) {
    console.log(id)
    this.treningService.Remove(id).subscribe((x: any) => {
      this.notificationService.showSuccess("Trening uspješno obrisan!", "Success!");
      this.getPodaci();
    }, (err) => this.notificationService.showError(err.error, 'Greška!'));
  }

}
