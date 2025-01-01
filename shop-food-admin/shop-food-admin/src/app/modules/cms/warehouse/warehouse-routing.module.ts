import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', loadChildren: () => import('./product/product.module').then(m => m.ProductModule) },
  { path: 'inventory', loadChildren: () => import('./inventory/inventory.module').then(m => m.InventoryModule) },
  { path: 'product', loadChildren: () => import('./product/product.module').then(m => m.ProductModule) },
  { path: 'supplier', loadChildren: () => import('./supplier/supplier.module').then(m => m.SupplierModule) },
  { path: 'transaction', loadChildren: () => import('./transaction/transaction.module').then(m => m.TransactionModule) },
  { path: 'unit', loadChildren: () => import('./unit/unit.module').then(m => m.UnitModule) },
  { path: 'warehouse', loadChildren: () => import('./warehouse/warehouse.module').then(m => m.WarehouseModule) },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WarehouseRoutingModule { }
