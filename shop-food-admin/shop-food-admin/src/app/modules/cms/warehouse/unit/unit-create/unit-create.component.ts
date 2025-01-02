import { Component } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { WarehouseService } from '../../../../../services/warehouse-service.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-unit-create',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './unit-create.component.html',
  styleUrl: './unit-create.component.scss'
})
export class UnitCreateComponent {

  name = new FormControl('Cái/Chiếc');
  constructor(
    private readonly _warehouseService: WarehouseService,
    private readonly _router: Router,
    private readonly _toastService: ToastrService
  ) { }
  onCreate() {
    const name = this.name.value ?? '';
    this._warehouseService.createUnit({
      name: name,
    }).subscribe((res) => {
      this._router.navigate(['/unit']);
      this._toastService.success('Create successfully');
    });
  }
}
