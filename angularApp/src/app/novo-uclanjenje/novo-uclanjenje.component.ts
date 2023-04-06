import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-novo-uclanjenje',
  templateUrl: './novo-uclanjenje.component.html',
  styleUrls: ['./novo-uclanjenje.component.css']
})
export class NovoUclanjenjeComponent implements OnInit {

  constructor(private router: Router,private route: ActivatedRoute,private httpKlijent : HttpClient)
  {}

  clanarinaId : any;

  ngOnInit(): void {
    this.clanarinaId = this.route.snapshot.paramMap.get('id');
    console.log(this.clanarinaId)
  }


}
