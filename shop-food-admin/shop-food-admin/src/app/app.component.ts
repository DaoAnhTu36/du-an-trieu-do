import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { WarehouseModule } from './warehouse/warehouse.module';
import { MenuComponent } from './menu/menu.component';
import { WarehouseServiceService } from './services/warehouse-service.service';
import { API_BASE_URL, AuthServiceService } from './services/auth-service.service';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, WarehouseModule, MenuComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  providers: [WarehouseServiceService
    , AuthServiceService
    , { provide: API_BASE_URL, useValue: environment.api }
  ]
})
export class AppComponent {
  title = 'shop-food-admin';
}
