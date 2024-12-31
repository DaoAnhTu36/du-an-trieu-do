import { Component } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { WarehouseService } from '../../../services/warehouse-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-warehouse-create',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './warehouse-create.component.html',
  styleUrl: './warehouse-create.component.scss'
})
export class WarehouseCreateComponent {
  name = new FormControl('Kho số 1');
  address = new FormControl('Số nhà 5A ngõ 221 Yên Xá Tân Triều Thanh Trì Hà Nội');
  constructor(
    private readonly _warehouseService: WarehouseService,
    private readonly _router: Router
  ) { }
  onCreate() {
    const name = this.name.value ?? '';
    const address = this.address.value ?? '';
    this._warehouseService.createWarehouse({
      name: name,
      address: address
    }).subscribe((response) => {
      this._router.navigate(['/warehouse/warehouse']);
    });
  }
}
