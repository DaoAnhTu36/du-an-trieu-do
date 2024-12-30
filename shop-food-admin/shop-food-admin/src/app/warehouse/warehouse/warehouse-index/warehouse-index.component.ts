import { Component } from '@angular/core';
import { WarehouseListModelRes, WarehouseService } from '../../../services/warehouse-service.service';
import { NgFor } from '@angular/common';

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
    private readonly _warehouseService: WarehouseService
  ) {
    _warehouseService.listWarehouse({
      pageNumber: 1,
      pageSize: 10,
    }).subscribe(res => {
      this.listWarehouse = res.data
    });
  }

  editWarehouse(id: string | undefined) {
    console.log(id);
  }

  deleteWarehouse(id: string | undefined) {
    console.log(id);
  }
}
