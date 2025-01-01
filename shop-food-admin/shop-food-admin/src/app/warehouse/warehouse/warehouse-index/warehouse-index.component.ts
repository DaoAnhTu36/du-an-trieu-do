import { Component } from '@angular/core';
import { WarehouseListModelRes, WarehouseService } from '../../../services/warehouse-service.service';
import { NgFor } from '@angular/common';
import { Router } from '@angular/router';
import { LoadingService } from '../../../commons/loading/loading.service';
import { PageingReq } from '../../../commons/const/ConstStatusCode';

@Component({
  selector: 'app-warehouse-index',
  standalone: true,
  imports: [NgFor],
  templateUrl: './warehouse-index.component.html',
  styleUrl: './warehouse-index.component.scss'
})
export class WarehouseIndexComponent {

  listWarehouse: WarehouseListModelRes | undefined;
  constructor(
    private readonly _warehouseService: WarehouseService,
    private readonly router: Router,
    private readonly _loadingService: LoadingService
  ) {
  }

  ngOnInit() {
    this.getListWarehouse();
  }

  getListWarehouse() {
    this._loadingService.show();
    this._warehouseService.listWarehouse({
      pageNumber: PageingReq.PAGE_NUMBER,
      pageSize: PageingReq.PAGE_SIZE,
    }).subscribe(res => {
      this.listWarehouse = res.data;
      this._loadingService.hide();
    });
  }

  addWarehouse() {
    this.router.navigate(["/warehouse/create"]);
  }

  editWarehouse(id: string | undefined) {
    this.router.navigate(["/warehouse/update/", id]);
  }

  detailWarehouse(id: string | undefined) {
    this.router.navigate(["/warehouse/detail/", id]);
  }

  deleteWarehouse(id: string | undefined) {
    this.router.navigate(["/warehouse/delete/", id]);
  }
}
