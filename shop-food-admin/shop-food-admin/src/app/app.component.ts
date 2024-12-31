import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { WarehouseModule } from './warehouse/warehouse.module';
import { MenuComponent } from './menu/menu.component';
import { API_WAREHOUSE_URL, WarehouseService } from './services/warehouse-service.service';
import { API_AUTH_URL, AuthService } from './services/auth-service.service';
import { environment } from '../environments/environment';
import { LoadingComponent } from "./commons/loading/loading.component";
import { LoadingService } from './commons/loading/loading.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    WarehouseModule,
    MenuComponent,
    LoadingComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  providers: [
    WarehouseService
    , AuthService
    , { provide: API_AUTH_URL, useValue: environment.API_AUTH_URL }
    , { provide: API_WAREHOUSE_URL, useValue: environment.API_WAREHOUSE_URL }
    , LoadingService
  ]
})
export class AppComponent {
  loading$: any;
  constructor(private loadingService: LoadingService) {

  }
  this.loading$ = this.loadingService.loading$;
title = 'shop-food-admin';
}
