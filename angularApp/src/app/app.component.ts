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
  loading : boolean = false;

  constructor(private _loading : LoadingService){}

  ngOnInit(): void {
    this.listenToLoading();
  }

  listenToLoading(): void {
    this._loading.loadingSub
      .pipe(delay(0)) // This prevents a ExpressionChangedAfterItHasBeenCheckedError for subsequent requests
      .subscribe((loading) => {
        this.loading = loading;
      });
  }
}
