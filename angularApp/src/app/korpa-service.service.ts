import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class KorpaServiceService {

  constructor() { }

  items: any[] = [];

  addItem(item: any) {
    this.items.push(item);
  }

  removeItem(item: any) {
    const index = this.items.indexOf(item);
    if (index !== -1) {
      this.items.splice(index, 1);
    }
  }

  getItems() {
    return this.items;
  }

  clearCart() {
    this.items = [];
  }
}
