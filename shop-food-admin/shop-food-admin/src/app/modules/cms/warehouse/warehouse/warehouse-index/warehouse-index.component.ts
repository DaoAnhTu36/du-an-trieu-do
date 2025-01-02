import { Component } from '@angular/core';
import { NgFor } from '@angular/common';
import { Router } from '@angular/router';
import { PageingReq } from '../../../../../commons/const/ConstStatusCode';
import { LoadingService } from '../../../../../commons/loading/loading.service';
import {
  WarehouseListModelRes,
  WarehouseService,
} from '../../../../../services/warehouse-service.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-warehouse-index',
  standalone: true,
  imports: [NgFor],
  templateUrl: './warehouse-index.component.html',
  styleUrl: './warehouse-index.component.scss',
})
export class WarehouseIndexComponent {
  listWarehouse: WarehouseListModelRes | undefined;
  constructor(
    private readonly _warehouseService: WarehouseService,
    private readonly router: Router,
    private readonly _loadingService: LoadingService,
    private readonly _toastService: ToastrService
  ) {}

  ngOnInit() {
    this.list();
  }

  list() {
    this._loadingService.show();
    this._warehouseService
      .listWarehouse({
        pageNumber: PageingReq.PAGE_NUMBER,
        pageSize: PageingReq.PAGE_SIZE,
      })
      .subscribe((res) => {
        this.listWarehouse = res.data;
        this._loadingService.hide();
      });
  }

  add() {
    this.router.navigate(['/wh/warehouse/create']);
  }

  edit(id: string | undefined) {
    this.router.navigate(['/wh/warehouse/update/', id]);
  }

  detail(id: string | undefined) {
    this.router.navigate(['/wh/warehouse/detail/', id]);
  }

  delete(id: string | undefined) {
    this.router.navigate(['/wh/warehouse/delete/', id]);
  }
}
