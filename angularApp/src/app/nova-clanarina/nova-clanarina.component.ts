import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-nova-clanarina',
  templateUrl: './nova-clanarina.component.html',
  styleUrls: ['./nova-clanarina.component.css']
})
export class NovaClanarinaComponent implements OnInit{
  @Input() novaClanarina:any;
  @Output() closeModal = new EventEmitter<void>();

  ngOnInit(): void {
  }

  spasiPromjene() {

  }
}
