import { Component } from '@angular/core';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss'
})
export class MenuComponent {

  data_menu = [
    {
      path: 'inventory',
      displayName: 'inventory',
    },
    {
      path: 'product',
      displayName: 'product',
    },
    {
      path: 'supplier',
      displayName: 'supplier',
    },
    {
      path: 'transaction',
      displayName: 'transaction',
    },
    {
      path: 'unit',
      displayName: 'unit',
    },
    {
      path: 'warehouse',
      displayName: 'warehouse',
    }
  ];
}
