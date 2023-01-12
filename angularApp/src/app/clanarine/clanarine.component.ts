import { Component } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-clanarine',
  templateUrl: './clanarine.component.html',
  styleUrls: ['./clanarine.component.css']
})
export class ClanarineComponent {

  constructor(private router : Router) {
  }

  redirekcijaNaSuplemente() {
    this.router.navigateByUrl("/shop")
  }
}
