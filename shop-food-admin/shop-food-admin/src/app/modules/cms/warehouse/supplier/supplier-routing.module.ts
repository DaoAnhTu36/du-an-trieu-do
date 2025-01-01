import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SupplierCreateComponent } from './supplier-create/supplier-create.component';
import { SupplierDeleteComponent } from './supplier-delete/supplier-delete.component';
import { SupplierIndexComponent } from './supplier-index/supplier-index.component';
import { SupplierUpdateComponent } from './supplier-update/supplier-update.component';

const routes: Routes = [
  { path: '', component: SupplierIndexComponent },
  { path: 'index', component: SupplierIndexComponent },
  { path: 'create', component: SupplierCreateComponent },
  { path: 'update', component: SupplierUpdateComponent },
  { path: 'delete', component: SupplierDeleteComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SupplierRoutingModule { }
