import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        loadChildren: () => import('./warehouse/warehouse.module').then(m => m.WarehouseModule)
    },
    {
        path: 'warehouse',
        loadChildren: () => import('./warehouse/warehouse.module').then(m => m.WarehouseModule)
    },
    {
        path: 'auth',
        loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule)
    },
];
