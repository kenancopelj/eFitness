import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements  OnInit{

  constructor(private HttpKlijent : HttpClient, private router : Router) {
  }
  ngOnInit(): void {
  }

  Redirekcija(redirekcijaNa: string) {
    this.router.navigate([redirekcijaNa])
  }
}
