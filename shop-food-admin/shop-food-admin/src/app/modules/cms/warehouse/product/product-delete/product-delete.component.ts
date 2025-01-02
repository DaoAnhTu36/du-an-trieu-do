import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StatusCodeApiResponse } from '../../../../../commons/const/ConstStatusCode';
import { LoadingService } from '../../../../../commons/loading/loading.service';
import { WarehouseService } from '../../../../../services/warehouse-service.service';

@Component({
  selector: 'app-product-delete',
  standalone: true,
  imports: [],
  templateUrl: './product-delete.component.html',
  styleUrl: './product-delete.component.scss',
})
export class ProductDeleteComponent {
  constructor(
    private readonly _warehouseService: WarehouseService,
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _loadingService: LoadingService,
    private readonly _router: Router
  ) {}

  ngOnInit() {
    this.delete();
  }

  delete() {
    this._loadingService.show();
    const id = this._activatedRoute.snapshot.params['id'];
    this._warehouseService
      .deleteProduct({
        id: id,
      })
      .subscribe((res) => {
        this._loadingService.hide();
        if (
          res.isNormal &&
          res.metaData?.statusCode === StatusCodeApiResponse.SUCCESS
        ) {
          this._router.navigate(['/wh/product']);
        }
      });
  }
}
