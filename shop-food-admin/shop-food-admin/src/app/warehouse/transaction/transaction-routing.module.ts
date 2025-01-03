import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TransactionCreateComponent } from './transaction-create/transaction-create.component';
import { TransactionDeleteComponent } from './transaction-delete/transaction-delete.component';
import { TransactionIndexComponent } from './transaction-index/transaction-index.component';
import { TransactionUpdateComponent } from './transaction-update/transaction-update.component';

const routes: Routes = [
  { path: '', component: TransactionIndexComponent },
  { path: 'index', component: TransactionIndexComponent },
  { path: 'create', component: TransactionCreateComponent },
  { path: 'update', component: TransactionUpdateComponent },
  { path: 'delete', component: TransactionDeleteComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TransactionRoutingModule { }
