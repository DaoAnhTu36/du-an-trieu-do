import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { LoadingService } from '../../../../../commons/loading/loading.service';
import { WarehouseService } from '../../../../../services/warehouse-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-transaction-index',
  standalone: true,
  imports: [],
  templateUrl: './transaction-index.component.html',
  styleUrl: './transaction-index.component.scss',
})
export class TransactionIndexComponent {
  constructor(
    private readonly _warehouseService: WarehouseService,
    private readonly router: Router,
    private readonly _loadingService: LoadingService,
    private readonly _toastService: ToastrService
  ) {}
  add() {
    this.router.navigate(['/wh/transaction/create']);
  }

  edit(id: string | undefined) {
    this.router.navigate(['/wh/transaction/update/', id]);
  }

  detail(id: string | undefined) {
    this.router.navigate(['/wh/transaction/detail/', id]);
  }

  delete(id: string | undefined) {
    this.router.navigate(['/wh/transaction/delete/', id]);
  }
}
