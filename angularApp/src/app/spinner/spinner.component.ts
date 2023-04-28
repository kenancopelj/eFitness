import { Component } from '@angular/core';
import { LoadingService } from './loading.service';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.css'],
})
export class SpinnerComponent {
  isLoading: Subject<boolean> = this.loaderService.isLoading;

  constructor(private loaderService: LoadingService) {}
}
