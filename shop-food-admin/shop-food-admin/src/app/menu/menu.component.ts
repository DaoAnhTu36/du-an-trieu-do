import { CommonModule, NgFor } from '@angular/common';
import { Component, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { CommonServiceService } from '../services/common-service.service';
import { LocalStorageServiceService } from '../services/local-storage-service.service';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [NgFor, CommonModule],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss'
})
export class MenuComponent {
  isShowMenu = false;
  prefix = 'warehouse/';
  prefixAuth = 'auth';
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
  data_notify = [
    {
      title: 'Notification 1',
      body: 'Content 1',
      time: '1 hour ago'
    },
    {
      title: 'Notification 2',
      body: 'Content 2',
      time: '2 hour ago'
    },
    {
      title: 'Notification 3',
      body: 'Content 3',
      time: '3 hour ago'
    },
    {
      title: 'Notification 4',
      body: 'Content 4',
      time: '4 hour ago'
    }
  ]
  customerName = 'DaoAnhTu'
  constructor(private route: Router,
    private _localStorage: LocalStorageServiceService,
  ) {
  }
  ngOnChanges(changes: SimpleChanges): void {
  }
  ngOnInit(): void {
  }
  ngDoCheck(): void {
    this.isShowMenu = !this.route.url.includes(this.prefixAuth);
    if (this.isShowMenu) {
      const dataCustomer = JSON.parse(this._localStorage.getData('CustomerInfor') ?? '{}');
      this.customerName = dataCustomer.name;
    }
  }
  redirectMenu(path: string) {
    this.route.navigateByUrl(path);
  }
}
