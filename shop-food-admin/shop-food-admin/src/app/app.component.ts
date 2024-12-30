import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { WarehouseModule } from './warehouse/warehouse.module';
import { MenuComponent } from './menu/menu.component';
import { API_WAREHOUSE_URL, WarehouseService } from './services/warehouse-service.service';
import { API_AUTH_URL, AuthService } from './services/auth-service.service';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet
    , WarehouseModule
    , MenuComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  providers: [
    WarehouseService
    , AuthService
    , { provide: API_AUTH_URL, useValue: environment.API_AUTH_URL }
    , { provide: API_WAREHOUSE_URL, useValue: environment.API_WAREHOUSE_URL }
  ]
})
export class AppComponent {
  title = 'shop-food-admin';
}
