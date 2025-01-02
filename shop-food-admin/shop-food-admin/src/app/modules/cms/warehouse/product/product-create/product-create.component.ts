import { Component } from '@angular/core';
import { ReactiveFormsModule, FormControl } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { StatusCodeApiResponse } from '../../../../../commons/const/ConstStatusCode';
import { WarehouseService } from '../../../../../services/warehouse-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-create',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './product-create.component.html',
  styleUrl: './product-create.component.scss',
})
export class ProductCreateComponent {
  name = new FormControl('');
  description = new FormControl('');
  constructor(
    private readonly _warehouseService: WarehouseService,
    private readonly _router: Router,
    private readonly _toastService: ToastrService
  ) {}
  create() {
    const nameValue = this.name.value ?? '';
    const descriptionValue = this.description.value ?? '';
    this._warehouseService
      .createProduct({
        name: nameValue,
        description: descriptionValue,
      })
      .subscribe((res) => {
        if (
          res.isNormal &&
          res.metaData?.statusCode == StatusCodeApiResponse.SUCCESS
        ) {
          this._router.navigate(['/wh/product']);
          this._toastService.success('Create successfully');
        } else {
          this._toastService.error(res.metaData?.message);
        }
      });
  }
}
