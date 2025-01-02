import { CommonModule, NgFor } from '@angular/common';
import { Component, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { CommonServiceService } from '../services/common-service.service';
import { LocalStorageServiceService } from '../services/local-storage-service.service';
import {
  NotificationModels,
  WarehouseService,
} from '../services/warehouse-service.service';
import { PageingReq } from '../commons/const/ConstStatusCode';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [NgFor, CommonModule],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss',
})
export class MenuComponent {
  isShowMenu = false;
  prefix = 'wh/';
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
    },
  ];
  data_notify: {
    title: string | undefined;
    body: string | undefined;
    time: Date;
  }[] = [];
  customerName = 'DaoAnhTu';
  isShowNotificationArea = false;
  constructor(
    private route: Router,
    private _localStorage: LocalStorageServiceService,
    private readonly _warehouseService: WarehouseService
  ) {}

  ngOnInit(): void {
    this.getListNotification();
  }

  ngDoCheck(): void {
    this.isShowMenu = !this.route.url.includes(this.prefixAuth);
    if (this.isShowMenu) {
      const dataCustomer = JSON.parse(
        this._localStorage.getData('CustomerInfor') ?? '{}'
      );
      this.customerName = dataCustomer.name;
    }
  }

  redirectMenu(path: string) {
    this.route.navigateByUrl(path);
  }

  toggleNotify() {
    if (!this.isShowNotificationArea) {
      this._warehouseService
        .notificationByUserId({
          pageNumber: PageingReq.PAGE_NUMBER,
          pageSize: PageingReq.PAGE_SIZE,
        })
        .subscribe((res) => {
          this.data_notify =
            res.data?.list?.map((item) => {
              return {
                title: item.title,
                body: item.body,
                time: item.createdDate,
              };
            }) ?? [];
          this.isShowNotificationArea = !this.isShowNotificationArea;
        });
    } else {
      this.isShowNotificationArea = !this.isShowNotificationArea;
    }
  }

  getListNotification() {}
}
