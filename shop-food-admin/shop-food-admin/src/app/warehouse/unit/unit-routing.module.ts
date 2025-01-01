import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UnitCreateComponent } from './unit-create/unit-create.component';
import { UnitDeleteComponent } from './unit-delete/unit-delete.component';
import { UnitIndexComponent } from './unit-index/unit-index.component';
import { UnitUpdateComponent } from './unit-update/unit-update.component';

const routes: Routes = [
  { path: '', component: UnitIndexComponent },
  { path: 'index', component: UnitIndexComponent },
  { path: 'create', component: UnitCreateComponent },
  { path: 'update', component: UnitUpdateComponent },
  { path: 'delete', component: UnitDeleteComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UnitRoutingModule { }
