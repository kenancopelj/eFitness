import { Component, OnInit } from '@angular/core';
import { LoadingService } from './spinner/loading.service';
import { delay } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: [
    './app.component.css',
]
})
export class AppComponent implements OnInit {

  title = 'angularApp';

  constructor(){}

  ngOnInit(): void {
  }

}
