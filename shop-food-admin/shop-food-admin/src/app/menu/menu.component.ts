import { NgFor } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [NgFor],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss'
})
export class MenuComponent {

  prefix = 'warehouse/';
  data_menu = [
    {
      path: ``,
      displayName: 'home',
    },
    {
      path: `${this.prefix}inventory`,
      displayName: 'inventory',
    },
    {
      path: `${this.prefix}product`,
      displayName: 'product',
    },
    {
      path: `${this.prefix}supplier`,
      displayName: 'supplier',
    },
    {
      path: `${this.prefix}transaction`,
      displayName: 'transaction',
    },
    {
      path: `${this.prefix}unit`,
      displayName: 'unit',
    },
    {
      path: `${this.prefix}warehouse`,
      displayName: 'warehouse',
    }
  ];
  customerName = 'DaoAnhTu'
}
