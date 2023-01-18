import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-konfig";

@Component({
  selector: 'app-clanarine',
  templateUrl: './clanarine.component.html',
  styleUrls: ['./clanarine.component.css']
})
export class ClanarineComponent implements OnInit{

  constructor(private router : Router, private httpKlijent : HttpClient) {
  }

  redirekcijaNaSuplemente() {
    this.router.navigateByUrl("/shop")
  }

  ngOnInit(): void {
    this.fetchVrsteClanarina();
  }

  fetchVrsteClanarina() {

  }
}
