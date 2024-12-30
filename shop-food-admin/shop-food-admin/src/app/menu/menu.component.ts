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
  customerName = 'DaoAnhTu'
  constructor(private route: Router,
    private readonly _localStorage: LocalStorageServiceService,
  ) {
  }
  ngOnChanges(changes: SimpleChanges): void {
  }
  ngOnInit(): void {
  }
  ngDoCheck(): void {
    this.isShowMenu = !this.route.url.includes(this.prefixAuth);
    if (this.isShowMenu) {
      this.customerName = JSON.parse(this._localStorage.getData('CustomerInfor') ?? '{}').name;
    }
  }
  ngAfterContentInit(): void {
  }
  ngAfterContentChecked(): void {
  }
  ngAfterViewInit(): void {
  }
  ngAfterViewChecked(): void {
  }
  ngOnDestroy(): void {
  }
}
