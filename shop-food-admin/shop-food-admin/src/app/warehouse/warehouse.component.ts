import { NgFor } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-warehouse',
  standalone: true,
  imports: [NgFor],
  templateUrl: './warehouse.component.html',
  styleUrl: './warehouse.component.scss'
})
export class WarehouseComponent {

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
